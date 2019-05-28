using IceCreamShopServiceDAL.Attributies;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace IceCreamShopServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с мороженщиками")]
    public interface IIcemanService
    {
        [CustomMethod("Метод получения списка мороженщиков")]
        List<IcemanViewModel> GetList();

        [CustomMethod("Метод получения мороженщика по id")]
        IcemanViewModel GetElement(int id);

        [CustomMethod("Метод добавления мороженщика")]
        void AddElement(IcemanBindingModel model);

        [CustomMethod("Метод изменения данных по мороженщику")]
        void UpdElement(IcemanBindingModel model);

        [CustomMethod("Метод удаления мороженщика")]
        void DelElement(int id);

        [CustomMethod("Метод получения свободного мороженщика")]
        IcemanViewModel GetFreeIceman();
    }
}