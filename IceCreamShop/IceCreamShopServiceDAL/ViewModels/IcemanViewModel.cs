using System.Runtime.Serialization;

namespace IceCreamShopServiceDAL.ViewModels
{
    [DataContract]
    public class IcemanViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string IcemanFIO { get; set; }
    }
}
