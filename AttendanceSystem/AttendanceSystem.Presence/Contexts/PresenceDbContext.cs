using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Presence.Entities;

namespace AttendanceSystem.Presence.Contexts
{
    public class PresenceDbContext : Context, IPresenceDbContext
    {
        public PresenceDbContext(string connectionString, string migrationAssembly) 
            : base(connectionString, migrationAssembly)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(a => a.Attendances)
                .WithOne(s => s.Student);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}
