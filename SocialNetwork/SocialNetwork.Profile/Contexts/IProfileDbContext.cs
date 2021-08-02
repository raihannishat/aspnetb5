using Microsoft.EntityFrameworkCore;
using SocialNetwork.Profile.Entities;

namespace SocialNetwork.Profile.Contexts
{
    public interface IProfileDbContext
    {
        DbSet<Member> Members { get; set; }
        DbSet<Photo> Photos { get; set; }
    }
}