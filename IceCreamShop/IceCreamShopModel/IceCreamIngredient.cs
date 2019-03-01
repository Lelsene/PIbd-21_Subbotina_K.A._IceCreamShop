namespace IceCreamShopModel
{
    /// <summary>
    /// Сколько ингредиентов, требуется для изготовления мороженого
    /// </summary>
    public class IceCreamIngredient
    {
        public int Id { get; set; }

        public int IceCreamId { get; set; }

        public int IngredientId { get; set; }

        public string IngredientName { get; set; }

        public int Count { get; set; }
    }
}
