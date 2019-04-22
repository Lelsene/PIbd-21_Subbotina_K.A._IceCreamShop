namespace IceCreamShopModel
{
    /// <summary>
    /// Сколько ингредиентов хранится в хранилище
    /// </summary>
    public class StorageIngredient
    {
        public int Id { get; set; }

        public int StorageId { get; set; }

        public int IngredientId { get; set; }

        public int Count { get; set; }
    }
}
