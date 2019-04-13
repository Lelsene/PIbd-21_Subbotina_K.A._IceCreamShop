using System.Runtime.Serialization;

namespace IceCreamShopServiceDAL.BindingModels
{
    [DataContract]
    public class BookingBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public int IceCreamId { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Sum { get; set; }
    }
}
