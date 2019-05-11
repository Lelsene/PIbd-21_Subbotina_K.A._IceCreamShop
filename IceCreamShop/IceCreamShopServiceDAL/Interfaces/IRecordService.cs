using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace IceCreamShopServiceDAL.Interfaces
{
    public interface IRecordService
    {
        void SaveIceCreamPrice(RecordBindingModel model);

        List<StoragesLoadViewModel> GetStoragesLoad();

        void SaveStoragesLoad(RecordBindingModel model);

        List<CustomerBookingsModel> GetCustomerBookings(RecordBindingModel model);

        void SaveCustomerBookings(RecordBindingModel model);
    }
}
