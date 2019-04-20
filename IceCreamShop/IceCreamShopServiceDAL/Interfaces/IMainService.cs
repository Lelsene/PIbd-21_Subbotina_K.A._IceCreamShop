﻿using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace IceCreamShopServiceDAL.Interfaces
{
    public interface IMainService
    {
        List<BookingViewModel> GetList();

        List<BookingViewModel> GetFreeBookings();

        void CreateBooking(BookingBindingModel model);

        void TakeBookingInWork(BookingBindingModel model);

        void FinishBooking(BookingBindingModel model);

        void PayBooking(BookingBindingModel model);

        void PutIngredientOnStorage(StorageIngredientBindingModel model);
    }
}
