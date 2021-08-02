using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Data;
using SocialNetwork.Profile.Repositories;

namespace SocialNetwork.Profile.UnitOfWorks
{
    public interface IProfileUnitOfWork : IUnitOfWork
    {
        IMemberRepository MemberRepository { get; }
        IPhotoRepository PhotoRepository { get; }
    }
}
