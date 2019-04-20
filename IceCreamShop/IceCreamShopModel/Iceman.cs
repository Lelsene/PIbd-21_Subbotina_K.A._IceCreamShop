using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceCreamShopModel
{
    /// <summary>
    /// Мороженщик, выполняющий заказы покупателей
    /// </summary>
    public class Iceman
    {
        public int Id { get; set; }

        [Required]
        public string IcemanFIO { get; set; }

        [ForeignKey("IcemanId")]
        public virtual List<Booking> Bookings { get; set; }
    }
}
