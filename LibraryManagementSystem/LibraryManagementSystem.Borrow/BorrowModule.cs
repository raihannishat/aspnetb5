using Autofac;
using LibraryManagementSystem.Borrow.Contexts;
using LibraryManagementSystem.Borrow.Services;
using LibraryManagementSystem.Borrow.Repositories;
using LibraryManagementSystem.Borrow.UnitOfWorks;

namespace LibraryManagementSystem.Borrow
{
    public class BorrowModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public BorrowModule(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BorrowDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<BorrowDbContext>().As<IBorrowDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<BookRepository>().As<IBookRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookService>().As<IBookService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuthorService>().As<IAuthorService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BorrowUnitOfWork>().As<IBorrowUnitOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
