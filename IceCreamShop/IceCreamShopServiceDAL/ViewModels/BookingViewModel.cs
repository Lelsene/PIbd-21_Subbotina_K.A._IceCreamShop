namespace IceCreamShopServiceDAL.ViewModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string CustomerFIO { get; set; }

        public int IceCreamId { get; set; }

        public string IceCreamName { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public string Status { get; set; }

        public string DateCreate { get; set; }

        public string DateImplement { get; set; }
    }
}
