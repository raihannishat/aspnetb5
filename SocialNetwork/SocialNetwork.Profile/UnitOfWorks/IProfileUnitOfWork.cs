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
