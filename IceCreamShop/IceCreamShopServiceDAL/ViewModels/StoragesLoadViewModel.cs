using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IceCreamShopServiceDAL.ViewModels
{
    [DataContract]
    public class StoragesLoadViewModel
    {
        [DataMember]
        public string StorageName { get; set; }

        [DataMember]
        public int TotalCount { get; set; }

        [DataMember]
        public IEnumerable<Tuple<string, int>> Ingredients { get; set; }
    }
}
