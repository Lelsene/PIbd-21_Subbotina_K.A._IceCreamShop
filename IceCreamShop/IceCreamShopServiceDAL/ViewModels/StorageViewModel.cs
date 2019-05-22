using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace IceCreamShopServiceDAL.ViewModels
{
    [DataContract]
    public class StorageViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Название хранилища")]
        public string StorageName { get; set; }

        [DataMember]
        public List<StorageIngredientViewModel> StorageIngredients { get; set; }
    }
}
