using Autofac;
using InventorySystem.Store.Contexts;
using InventorySystem.Store.Services;
using InventorySystem.Store.Repositories;
using InventorySystem.Store.UnitOfWorks;

namespace InventorySystem.Store
{
    public class StoreModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public StoreModule(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StoreDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<StoreDbContext>().As<IStoreDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StockService>().As<IStockService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>().As<IProductRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StockRepository>().As<IStockRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StoreUnitOfWork>().As<IStoreUnitOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
