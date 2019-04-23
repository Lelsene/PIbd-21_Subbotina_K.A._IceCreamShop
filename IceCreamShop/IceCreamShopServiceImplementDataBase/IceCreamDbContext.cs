using IceCreamShopModel;
using System.Data.Entity;

namespace IceCreamShopServiceImplementDataBase
{
    public class IceCreamDbContext : DbContext
    {
        public IceCreamDbContext() : base("IceCreamDatabase")
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied =
            System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Ingredient> Ingredients { get; set; }

        public virtual DbSet<Booking> Bookings { get; set; }

        public virtual DbSet<IceCream> IceCreams { get; set; }

        public virtual DbSet<IceCreamIngredient> IceCreamIngredients { get; set; }

        public virtual DbSet<Storage> Storages { get; set; }

        public virtual DbSet<StorageIngredient> StorageIngredients { get; set; }
    }
}
