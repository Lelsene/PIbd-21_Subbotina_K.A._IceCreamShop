using System;

namespace IceCreamShopServiceDAL.BindingModels
{
    public class RecordBindingModel
    {
        public string FileName { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }
    }
}
