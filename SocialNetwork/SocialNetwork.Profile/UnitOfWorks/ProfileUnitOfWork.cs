using SocialNetwork.Profile.Repositories;
using SocialNetwork.Data;
using SocialNetwork.Profile.Contexts;

namespace SocialNetwork.Profile.UnitOfWorks
{
    public class ProfileUnitOfWork : UnitOfWork, IProfileUnitOfWork
    {
        public ProfileUnitOfWork(IProfileDbContext dbContext, 
            IMemberRepository memberRepository, 
            IPhotoRepository photoRepository) : base((Context)dbContext)
        {
            MemberRepository = memberRepository;
            PhotoRepository = photoRepository;
        }

        public IMemberRepository MemberRepository { get; private set; }
        public IPhotoRepository PhotoRepository { get; private set; }
    }
}
