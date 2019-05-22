using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IceCreamShopServiceDAL.BindingModels
{
    [DataContract]
    public class IceCreamBindingModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string IceCreamName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public List<IceCreamIngredientBindingModel> IceCreamIngredients { get; set; }
    }
}
