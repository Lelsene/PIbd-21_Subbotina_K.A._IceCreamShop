using IceCreamShopServiceDAL.Attributies;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace IceCreamShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с мороженым")]
    public interface IIceCreamService
    {
        [CustomMethod("Метод получения списка мороженого")]
        List<IceCreamViewModel> GetList();

        [CustomMethod("Метод получения мороженого по id")]
        IceCreamViewModel GetElement(int id);

        [CustomMethod("Метод добавления мороженого")]
        void AddElement(IceCreamBindingModel model);

        [CustomMethod("Метод изменения данных по мороженому")]
        void UpdElement(IceCreamBindingModel model);

        [CustomMethod("Метод удаления мороженого")]
        void DelElement(int id);
    }
}
