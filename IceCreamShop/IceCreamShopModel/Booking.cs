using System;

namespace IceCreamShopModel
{
    /// <summary>
    /// Заказ покупателя
    /// </summary>
    public class Booking
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int IceCreamId { get; set; }

        public int? IcemanId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public BookingStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual IceCream IceCream { get; set; }

        public virtual Iceman Iceman { get; set; }
    }
}