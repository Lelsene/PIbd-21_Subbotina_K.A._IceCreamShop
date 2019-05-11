using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceImplementDataBase;
using IceCreamShopServiceImplementDataBase.Implementations;
using System;
using System.Data.Entity;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

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
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, IceCreamWebDbContext>(new HierarchicalLifetimeManager());
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
