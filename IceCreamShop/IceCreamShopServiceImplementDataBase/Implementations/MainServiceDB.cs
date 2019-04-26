using IceCreamShopModel;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace IceCreamShopServiceImplementDataBase.Implementations
{
    public class MainServiceDB : IMainService
    {
        private IceCreamWebDbContext context;
        public MainServiceDB(IceCreamWebDbContext context)
        {
            this.context = context;
        }

        public MainServiceDB()
        {
            this.context = new IceCreamWebDbContext();
        }

        public List<BookingViewModel> GetList()
        {
            List<BookingViewModel> result = context.Bookings.Select(rec => new BookingViewModel
            {
                Id = rec.Id,
                CustomerId = rec.CustomerId,
                IceCreamId = rec.IceCreamId,
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
                IceCreamName = rec.IceCream.IceCreamName
            })
            .ToList();
            return result;
        }
        public void CreateBooking(BookingBindingModel model)
        {
            context.Bookings.Add(new Booking
            {
                CustomerId = model.CustomerId,
                IceCreamId = model.IceCreamId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = BookingStatus.Принят
            });
            context.SaveChanges();
        }
        public void TakeBookingInWork(BookingBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Booking element = context.Bookings.FirstOrDefault(rec => rec.Id ==
                    model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.Status != BookingStatus.Принят)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
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
                    element.DateImplement = DateTime.Now;
                    element.Status = BookingStatus.Готовится;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
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
    }
}