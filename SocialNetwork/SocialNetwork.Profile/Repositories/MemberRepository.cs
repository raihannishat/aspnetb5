using SocialNetwork.Data;
using SocialNetwork.Profile.Entities;
using SocialNetwork.Profile.Contexts;

namespace SocialNetwork.Profile.Repositories
{
    public class MemberRepository : Repository<Member, int>, IMemberRepository
    {
        public MemberRepository(IProfileDbContext context) : base((Context)context)
        {

        }
    }
}
