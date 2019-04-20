using System.Runtime.Serialization;

namespace IceCreamShopServiceDAL.BindingModels
{
    [DataContract]
    public class IcemanBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string IcemanFIO { get; set; }
    }
}