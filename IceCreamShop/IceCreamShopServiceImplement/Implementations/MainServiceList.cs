using IceCreamShopModel;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IceCreamShopServiceImplement.Implementations
{
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;

        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<BookingViewModel> GetList()
        {
            List<BookingViewModel> result = source.Bookings.Select(rec => new BookingViewModel
            {
                Id = rec.Id,
                CustomerId = rec.CustomerId,
                IceCreamId = rec.IceCreamId,
                DateCreate = rec.DateCreate.ToLongDateString(),
                DateImplement = rec.DateImplement?.ToLongDateString(),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                CustomerFIO = source.Customers.FirstOrDefault(recC => recC.Id == rec.CustomerId)?.CustomerFIO,
                IceCreamName = source.IceCreams.FirstOrDefault(recP => recP.Id == rec.IceCreamId)?.IceCreamName,
            })
            .ToList();
            return result;
        }

        public void CreateBooking(BookingBindingModel model)
        {
            int maxId = source.Bookings.Count > 0 ? source.Bookings.Max(rec => rec.Id) : 0;
            source.Bookings.Add(new Booking
            {
                Id = maxId + 1,
                CustomerId = model.CustomerId,
                IceCreamId = model.IceCreamId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = BookingStatus.Принят
            });
        }

        public void TakeBookingInWork(BookingBindingModel model)
        {
            Booking element = source.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            // смотрим по количеству компонентов на складах
            var icecreamIngredients = source.IceCreamIngredients.Where(rec => rec.IceCreamId == element.IceCreamId);
            foreach (var icecreamIngredient in icecreamIngredients)
            {
                int countOnStorages = source.StorageIngredients
                    .Where(rec => rec.IngredientId == icecreamIngredient.IngredientId)
                    .Sum(rec => rec.Count);
                if (countOnStorages < icecreamIngredient.Count * element.Count)
                {
                    var IngredientName = source.Ingredients.FirstOrDefault(rec => rec.Id == icecreamIngredient.IngredientId);
                    throw new Exception("Не достаточно ингредиента " + IngredientName?.IngredientName + " требуется " + (icecreamIngredient.Count * element.Count) + ", в наличии " + countOnStorages);
                }
            }
            // списываем
            foreach (var icecreamIngredient in icecreamIngredients)
            {
                int countOnStorages = icecreamIngredient.Count * element.Count;
                var StorageIngredients = source.StorageIngredients.Where(rec => rec.IngredientId
                == icecreamIngredient.IngredientId);
                foreach (var StorageIngredient in StorageIngredients)
                {
                    // ингредиентов в одном хранилище может не хватать
                    if (StorageIngredient.Count >= countOnStorages)
                    {
                        StorageIngredient.Count -= countOnStorages;
                        break;
                    }
                    else
                    {
                        countOnStorages -= StorageIngredient.Count;
                        StorageIngredient.Count = 0;
                    }
                }
            }
            element.DateImplement = DateTime.Now;
            element.Status = BookingStatus.Готовится;
        }

        public void FinishBooking(BookingBindingModel model)
        {
            Booking element = source.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Готовится)
            {
                throw new Exception("Заказ не в статусе \"Готовится\"");
            }
            element.Status = BookingStatus.Готов;
        }

        public void PayBooking(BookingBindingModel model)
        {
            Booking element = source.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = BookingStatus.Оплачен;
        }

        public void PutIngredientOnStorage(StorageIngredientBindingModel model)
        {
            StorageIngredient element = source.StorageIngredients.FirstOrDefault(rec =>
            rec.StorageId == model.StorageId && rec.IngredientId == model.IngredientId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.StorageIngredients.Count > 0 ?
                source.StorageIngredients.Max(rec => rec.Id) : 0;
                source.StorageIngredients.Add(new StorageIngredient
                {
                    Id = ++maxId,
                    StorageId = model.StorageId,
                    IngredientId = model.IngredientId,
                    Count = model.Count
                });
            }
        }
    }
}
