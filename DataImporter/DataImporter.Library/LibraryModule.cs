using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using System.Threading.Tasks;
using DataImporter.Library.Contexts;
using DataImporter.Library.Services;
using DataImporter.Library.Repositories;
using DataImporter.Library.UnitOfWorks;

namespace DataImporter.Library
{
    public class LibraryModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public LibraryModule(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataImporterDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<DataImporterDbContext>().As<IDataImporterDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<ContentRepository>().As<IContentRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExcelFileRepository>().As<IExcelFileRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GroupRepository>().As<IGroupRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ContentService>().As<IContentService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExcelFileService>().As<IExcelFileService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GroupService>().As<IGroupService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DataImporterUnitOfWork>().As<IDataImporterUnitOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
