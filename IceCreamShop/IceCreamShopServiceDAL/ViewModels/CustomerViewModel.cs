using System.Runtime.Serialization;

namespace IceCreamShopServiceDAL.ViewModels
{
    [DataContract]
    public class CustomerViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CustomerFIO { get; set; }
    }
}
