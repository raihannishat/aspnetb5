using Autofac;
using SocialNetwork.Profile.Contexts;
using SocialNetwork.Profile.Services;
using SocialNetwork.Profile.Repositories;
using SocialNetwork.Profile.UnitOfWorks;

namespace SocialNetwork.Profile
{
    public class ProfileModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public ProfileModule(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProfileDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<ProfileDbContext>().As<IProfileDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<MemberService>().As<IMemberService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PhotoService>().As<IPhotoService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MemberRepository>().As<IMemberRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PhotoRepository>().As<IPhotoRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProfileUnitOfWork>().As<IProfileUnitOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
