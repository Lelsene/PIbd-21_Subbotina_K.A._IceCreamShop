using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceCreamShopModel
{
    /// <summary>
    /// Покупатель лавки
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string CustomerFIO { get; set; }

        public string Mail { get; set; }

        [ForeignKey("CustomerId")]
        public virtual List<Booking> Bookings { get; set; }

        [ForeignKey("CustomerId")]
        public virtual List<MessageInfo> MessageInfos { get; set; }
    }
}
