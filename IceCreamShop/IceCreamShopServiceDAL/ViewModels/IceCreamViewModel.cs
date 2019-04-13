using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IceCreamShopServiceDAL.ViewModels
{
    [DataContract]
    public class IceCreamViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string IceCreamName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public List<IceCreamIngredientViewModel> IceCreamIngredients { get; set; }
    }
}
