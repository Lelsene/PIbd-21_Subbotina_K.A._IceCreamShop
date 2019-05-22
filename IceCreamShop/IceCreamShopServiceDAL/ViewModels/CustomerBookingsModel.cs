using System.Runtime.Serialization;

namespace IceCreamShopServiceDAL.ViewModels
{
    [DataContract]
    public class CustomerBookingsModel
    {
        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public string DateCreate { get; set; }

        [DataMember]
        public string IceCreamName { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Sum { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}
