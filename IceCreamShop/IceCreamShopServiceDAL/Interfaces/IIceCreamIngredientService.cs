using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace IceCreamShopServiceDAL.Interfaces
{
    public interface IIceCreamIngredientService
    {
        List<IceCreamIngredientViewModel> GetList();

        IceCreamIngredientViewModel GetElement(int id);

        void AddElement(IceCreamIngredientBindingModel model);

        void UpdElement(IceCreamIngredientBindingModel model);

        void DelElement(int id);
    }
}
