using Autofac;
using ECommerceSystem.Sales.Contexts;
using ECommerceSystem.Sales.Services;
using ECommerceSystem.Sales.Repositories;
using ECommerceSystem.Sales.UnitOfWorks;

namespace ECommerceSystem.Sales
{
    public class SalesModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public SalesModule(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SalesDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<SalesDbContext>().As<ISalesDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>().As<IProductRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SalesUnitOfWork>().As<ISalesUnitOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
