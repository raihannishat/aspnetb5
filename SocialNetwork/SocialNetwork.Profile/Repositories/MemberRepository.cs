using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Data;
using SocialNetwork.Profile.Entities;
using SocialNetwork.Profile.Contexts;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Profile.Repositories
{
    public class MemberRepository : Repository<Member, int>, IMemberRepository
    {
        public MemberRepository(IProfileDbContext context) : base((Context)context)
        {

        }
    }
}
