namespace IceCreamShopServiceDAL.ViewModels
{
    public class IceCreamIngredientViewModel
    {
        public int Id { get; set; }

        public int IceCreamId { get; set; }

        public int IngredientId { get; set; }

        public string IngredientName { get; set; }

        public int Count { get; set; }
    }
}
