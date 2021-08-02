using SocialNetwork.Data;
using SocialNetwork.Profile.Entities;
using SocialNetwork.Profile.Contexts;

namespace SocialNetwork.Profile.Repositories
{
    public class PhotoRepository : Repository<Photo, int>, IPhotoRepository
    {
        public PhotoRepository(IProfileDbContext context) : base((Context)context)
        {

        }
    }
}
