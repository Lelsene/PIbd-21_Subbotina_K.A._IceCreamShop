using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IceCreamShopModel
{
    /// <summary>
    /// Хранилиище ингредиентов в лавке
    /// </summary>
    public class Storage
    {
        public int Id { get; set; }

        [Required]
        public string StorageName { get; set; }

        public virtual List<StorageIngredient> StorageIngredients { get; set; }
    }
}
