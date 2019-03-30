namespace IceCreamShopServiceDAL.ViewModels
{
    public class CustomerBookingsModel
    {
        public string CustomerName { get; set; }

        public string DateCreate { get; set; }

        public string IceCreamName { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public string Status { get; set; }
    }
}
