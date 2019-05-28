using IceCreamShopServiceDAL.Attributies;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace IceCreamShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с отчетами")]
    public interface IRecordService
    {
        [CustomMethod("Метод сохранения отчета о стоимости мороженого")]
        void SaveIceCreamPrice(RecordBindingModel model);

        [CustomMethod("Метод получения списка загруженности хранилищ")]
        List<StoragesLoadViewModel> GetStoragesLoad();

        [CustomMethod("Метод сохранения отчета о загруженности хранилищ")]
        void SaveStoragesLoad(RecordBindingModel model);

        [CustomMethod("Метод получения списка заказов покупателей")]
        List<CustomerBookingsModel> GetCustomerBookings(RecordBindingModel model);

        [CustomMethod("Метод сохранения отчета о заказах покупателей")]
        void SaveCustomerBookings(RecordBindingModel model);
    }
}
