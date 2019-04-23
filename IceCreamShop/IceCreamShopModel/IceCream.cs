using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceCreamShopModel
{
    /// <summary>
    /// Мороженое, изготавливаемое в лавке
    /// </summary>
    public class IceCream
    {
        public int Id { get; set; }

        [Required]
        public string IceCreamName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual List<Booking> Bookings { get; set; }
    }
}
