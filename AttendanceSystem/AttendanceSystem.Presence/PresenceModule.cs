using Autofac;
using AttendanceSystem.Presence.Contexts;
using AttendanceSystem.Presence.Services;
using AttendanceSystem.Presence.Repositories;
using AttendanceSystem.Presence.UnitOfWorks;

namespace AttendanceSystem.Presence
{
    public class PresenceModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public PresenceModule(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PresenceDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<PresenceDbContext>().As<IPresenceDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentService>().As<IStudentService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AttendanceService>().As<IAttendanceService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentRepository>().As<IStudentRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AttendanceRepository>().As<IAttendanceRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PresenceUnitOfWork>().As<IPresenceUnifOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
