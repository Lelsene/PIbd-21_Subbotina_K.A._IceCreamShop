using System.Collections.Generic;
using System.ComponentModel;

namespace IceCreamShopServiceDAL.ViewModels
{
    public class StorageViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название хранилища")]
        public string StorageName { get; set; }

        public List<StorageIngredientViewModel> StorageIngredients { get; set; }
    }
}
