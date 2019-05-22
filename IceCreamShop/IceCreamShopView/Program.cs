using System;
using System.Windows.Forms;

namespace IceCreamShopView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            APIClient.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, IceCreamDbContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICustomerService, CustomerServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IIngredientService, IngredientServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IIceCreamService, IceCreamServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IRecordService, RecordServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorageService, StorageServiceDB>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
