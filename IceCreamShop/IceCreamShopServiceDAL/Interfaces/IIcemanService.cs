using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace IceCreamShopServiceDAL.Interfaces
{
    public interface IIcemanService
    {
        List<IcemanViewModel> GetList();

        IcemanViewModel GetElement(int id);

        void AddElement(IcemanBindingModel model);

        void UpdElement(IcemanBindingModel model);

        void DelElement(int id);

        IcemanViewModel GetFreeIceman();
    }
}