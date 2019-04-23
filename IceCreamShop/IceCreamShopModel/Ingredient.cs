using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IceCreamShopModel
{
    /// <summary>
    /// Ингредиент, требуемый для изготовления мороженого
    /// </summary>
    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        public string IngredientName { get; set; }

        public virtual List<IceCreamIngredient> IceCreamIngredients { get; set; }

        public virtual List<StorageIngredient> StorageIngredients { get; set; }
    }
}
