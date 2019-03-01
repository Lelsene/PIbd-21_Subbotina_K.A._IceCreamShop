using System.Collections.Generic;

namespace IceCreamShopServiceDAL.ViewModels
{
    public class IceCreamViewModel
    {
        public int Id { get; set; }

        public string IceCreamName { get; set; }

        public decimal Price { get; set; }

        public List<IceCreamIngredientViewModel> IceCreamIngredients { get; set; }
    }
}
