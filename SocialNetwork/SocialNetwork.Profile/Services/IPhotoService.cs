using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Profile.BusinessObjects;

namespace SocialNetwork.Profile.Services
{
    public interface IPhotoService
    {
        IList<Photo> GetAllPhotos();
        void CreatePhoto(Photo photo);
        (IList<Photo> records, int total, int totalDisplay) GetPhotos(int pageIndex, int pageSize, string searchText, string sortText);
        Photo GetPhoto(int id);
        void UpdatePhoto(Photo photo);
        void DeletePhoto(int photoId);
    }
}
