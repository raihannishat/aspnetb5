using Microsoft.EntityFrameworkCore;
using SocialNetwork.Profile.Entities;

namespace SocialNetwork.Profile.Contexts
{
    public class ProfileDbContext : Context, IProfileDbContext
    {
        public ProfileDbContext(string connectionString, string migrationAssembly) 
            : base(connectionString, migrationAssembly)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Member>()
                .HasMany(p => p.Photos)
                .WithOne(m => m.Member);

            base.OnModelCreating(builder);
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
