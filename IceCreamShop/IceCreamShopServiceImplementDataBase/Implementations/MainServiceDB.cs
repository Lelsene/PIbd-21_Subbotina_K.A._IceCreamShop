using IceCreamShopModel;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace IceCreamShopServiceImplementDataBase.Implementations
{
    public class MainServiceDB : IMainService
    {
        private IceCreamDbContext context;

        public MainServiceDB(IceCreamDbContext context)
        {
            this.context = context;
        }

        public List<BookingViewModel> GetList()
        {
            List<BookingViewModel> result = context.Bookings.Select(rec => new BookingViewModel
            {
                Id = rec.Id,
                CustomerId = rec.CustomerId,
                IceCreamId = rec.IceCreamId,
                IcemanId = rec.IcemanId,
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
                             SqlFunctions.DateName("mm", rec.DateCreate) + " " +
                            SqlFunctions.DateName("yyyy", rec.DateCreate),
                DateImplement = rec.DateImplement == null ? "" :
                            SqlFunctions.DateName("dd",
                            rec.DateImplement.Value) + " " +
                            SqlFunctions.DateName("mm",
                            rec.DateImplement.Value) + " " +
                            SqlFunctions.DateName("yyyy",
                            rec.DateImplement.Value),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                CustomerFIO = rec.Customer.CustomerFIO,
                IceCreamName = rec.IceCream.IceCreamName,
                IcemanFIO = rec.Iceman.IcemanFIO
            })
            .ToList();
            return result;
        }

        public void CreateBooking(BookingBindingModel model)
        {
            var booking = new Booking
            {
                CustomerId = model.CustomerId,
                IceCreamId = model.IceCreamId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = BookingStatus.Принят
            };
            context.Bookings.Add(booking);
            context.SaveChanges();
            var customer = context.Customers.FirstOrDefault(x => x.Id == model.CustomerId);
            SendEmail(customer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от { 1} cоздан успешно", booking.Id, booking.DateCreate.ToShortDateString()));
        }

        public void TakeBookingInWork(BookingBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                Booking element = context.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
                try
                {
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if ((element.Status != BookingStatus.Принят) && (element.Status != BookingStatus.НедостаточноРесурсов))
                    {
                        throw new Exception("Заказ не в статусе \"Принят\" или \"Недостаточно ресурсов\"");
                    }
                    var icecreamIngredients = context.IceCreamIngredients.Include(rec =>
                    rec.Ingredient).Where(rec => rec.IceCreamId == element.IceCreamId);
                    // списываем
                    foreach (var icecreamIngredient in icecreamIngredients)
                    {
                        int countOnStorages = icecreamIngredient.Count * element.Count;
                        var stockIngredients = context.StorageIngredients.Where(rec =>
                        rec.IngredientId == icecreamIngredient.IngredientId);
                        foreach (var stockIngredient in stockIngredients)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (stockIngredient.Count >= countOnStorages)
                            {
                                stockIngredient.Count -= countOnStorages;
                                countOnStorages = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnStorages -= stockIngredient.Count;
                                stockIngredient.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnStorages > 0)
                        {
                            throw new Exception("Не достаточно ингредиента" + icecreamIngredient.Ingredient.IngredientName + " требуется " + icecreamIngredient.Count + ", не хватает " + countOnStorages);
                        }
                    }
                    element.IcemanId = model.IcemanId;
                    element.DateImplement = DateTime.Now;
                    element.Status = BookingStatus.Готовится;
                    context.SaveChanges();
                    SendEmail(element.Customer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} передеан в работу", element.Id, element.DateCreate.ToShortDateString()));
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    element.Status = BookingStatus.НедостаточноРесурсов;
                    context.SaveChanges();
                    throw;
                }
            }
        }

        public void FinishBooking(BookingBindingModel model)
        {
            Booking element = context.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Готовится)
            {
                throw new Exception("Заказ не в статусе \"Готовится\"");
            }
            element.Status = BookingStatus.Готов;
            context.SaveChanges();
            SendEmail(element.Customer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} передан на оплату", element.Id, element.DateCreate.ToShortDateString()));
        }

        public void PayBooking(BookingBindingModel model)
        {
            Booking element = context.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = BookingStatus.Оплачен;
            context.SaveChanges();
            SendEmail(element.Customer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} оплачен успешно", element.Id, element.DateCreate.ToShortDateString()));
        }

        public void PutIngredientOnStorage(StorageIngredientBindingModel model)
        {
            StorageIngredient element = context.StorageIngredients.FirstOrDefault(rec =>
            rec.StorageId == model.StorageId && rec.IngredientId == model.IngredientId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.StorageIngredients.Add(new StorageIngredient
                {
                    StorageId = model.StorageId,
                    IngredientId = model.IngredientId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }

        public List<BookingViewModel> GetFreeBookings()
        {
            List<BookingViewModel> result = context.Bookings
                .Where(x => x.Status == BookingStatus.Принят || x.Status == BookingStatus.НедостаточноРесурсов)
                .Select(rec => new BookingViewModel
                {
                    Id = rec.Id
                })
                .ToList();
            return result;
        }

        private void SendEmail(string mailAddress, string subject, string text)
        {
            MailMessage objMailMessage = new MailMessage();
            SmtpClient objSmtpClient = null;
            try
            {
                objMailMessage.From = new
                MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                objMailMessage.To.Add(new MailAddress(mailAddress));
                objMailMessage.Subject = subject;
                objMailMessage.Body = text;
                objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;

                objSmtpClient = new SmtpClient("smtp.gmail.com", 587);
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.EnableSsl = true;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpClient.Credentials = new
                NetworkCredential(ConfigurationManager.AppSettings["MailLogin"],
                ConfigurationManager.AppSettings["MailPassword"]);

                objSmtpClient.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMailMessage = null;
                objSmtpClient = null;
            }
        }
    }
}