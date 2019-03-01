using IceCreamShopModel;
using System.Collections.Generic;

namespace IceCreamShopServiceImplement
{
    class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Customer> Customers { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<Booking> Bookings { get; set; }

        public List<IceCream> IceCreams { get; set; }

        public List<IceCreamIngredient> IceCreamIngredients { get; set; }

        private DataListSingleton()
        {
            Customers = new List<Customer>();
            Ingredients = new List<Ingredient>();
            Bookings = new List<Booking>();
            IceCreams = new List<IceCream>();
            IceCreamIngredients = new List<IceCreamIngredient>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
