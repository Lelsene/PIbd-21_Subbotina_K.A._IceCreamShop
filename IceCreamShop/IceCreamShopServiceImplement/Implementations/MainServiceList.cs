using IceCreamShopModel;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;

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
            List<BookingViewModel> result = new List<BookingViewModel>();
            for (int i = 0; i < source.Bookings.Count; ++i)
            {
                string CustomerFIO = string.Empty;
                for (int j = 0; j < source.Customers.Count; ++j)
                {
                    if (source.Customers[j].Id == source.Bookings[i].CustomerId)
                    {
                        CustomerFIO = source.Customers[j].CustomerFIO;
                        break;
                    }
                }
                string IceCreamName = string.Empty;
                for (int j = 0; j < source.IceCreams.Count; ++j)
                {
                    if (source.IceCreams[j].Id == source.Bookings[i].IceCreamId)
                    {
                        IceCreamName = source.IceCreams[j].IceCreamName;
                        break;
                    }
                }
                result.Add(new BookingViewModel
                {
                    Id = source.Bookings[i].Id,
                    CustomerId = source.Bookings[i].CustomerId,
                    CustomerFIO = CustomerFIO,
                    IceCreamId = source.Bookings[i].IceCreamId,
                    IceCreamName = IceCreamName,
                    Count = source.Bookings[i].Count,
                    Sum = source.Bookings[i].Sum,
                    DateCreate = source.Bookings[i].DateCreate.ToLongDateString(),
                    DateImplement = source.Bookings[i].DateImplement?.ToLongDateString(),
                    Status = source.Bookings[i].Status.ToString()
                });
            }
            return result;
        }

        public void CreateBooking(BookingBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Bookings.Count; ++i)
            {
                if (source.Bookings[i].Id > maxId)
                {
                    maxId = source.Customers[i].Id;
                }
            }
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
            int index = -1;
            for (int i = 0; i < source.Bookings.Count; ++i)
            {
                if (source.Bookings[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Bookings[index].Status != BookingStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            source.Bookings[index].DateImplement = DateTime.Now;
            source.Bookings[index].Status = BookingStatus.Готовится;
        }

        public void FinishBooking(BookingBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Bookings.Count; ++i)
            {
                if (source.Customers[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Bookings[index].Status != BookingStatus.Готовится)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            source.Bookings[index].Status = BookingStatus.Готов;
        }

        public void PayBooking(BookingBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Bookings.Count; ++i)
            {
                if (source.Customers[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Bookings[index].Status != BookingStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            source.Bookings[index].Status = BookingStatus.Оплачен;
        }
    }
}
