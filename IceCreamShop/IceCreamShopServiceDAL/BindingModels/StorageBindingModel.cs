using System.Runtime.Serialization;

namespace IceCreamShopServiceDAL.BindingModels
{
    [DataContract]
    public class StorageBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string StorageName { get; set; }
    }
}
