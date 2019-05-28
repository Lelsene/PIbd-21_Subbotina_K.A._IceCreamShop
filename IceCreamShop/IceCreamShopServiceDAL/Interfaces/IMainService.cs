using IceCreamShopServiceDAL.Attributies;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace IceCreamShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с заказами")]
    public interface IMainService
    {
        [CustomMethod("Метод получения списка заказов")]
        List<BookingViewModel> GetList();

        [CustomMethod("Метод получения списка необработанных заказов")]
        List<BookingViewModel> GetFreeBookings();

        [CustomMethod("Метод создания заказа")]
        void CreateBooking(BookingBindingModel model);

        [CustomMethod("Метод принятия заказа в работу")]
        void TakeBookingInWork(BookingBindingModel model);

        [CustomMethod("Метод завершения работы над заказом")]
        void FinishBooking(BookingBindingModel model);

        [CustomMethod("Метод оплаты заказа")]
        void PayBooking(BookingBindingModel model);

        [CustomMethod("Метод пополнения хранилищей ингредиентами")]
        void PutIngredientOnStorage(StorageIngredientBindingModel model);
    }
}
