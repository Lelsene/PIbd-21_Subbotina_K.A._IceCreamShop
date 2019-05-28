using IceCreamShopServiceDAL.Attributies;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace IceCreamShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с покупателями")]
    public interface ICustomerService
    {
        [CustomMethod("Метод получения списка покупателей")]
        List<CustomerViewModel> GetList();

        [CustomMethod("Метод получения покупателя по id")]
        CustomerViewModel GetElement(int id);

        [CustomMethod("Метод добавления покупателя")]
        void AddElement(CustomerBindingModel model);

        [CustomMethod("Метод изменения данных по покупателю")]
        void UpdElement(CustomerBindingModel model);

        [CustomMethod("Метод удаления покупателя")]
        void DelElement(int id);
    }
}
