using System.Runtime.Serialization;

namespace IceCreamShopServiceDAL.BindingModels
{
    [DataContract]
    public class IceCreamIngredientBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int IceCreamId { get; set; }

        [DataMember]
        public int IngredientId { get; set; }

        [DataMember]
        public string IngredientName { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
