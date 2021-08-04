using System;
using System.Linq;
using System.Collections.Generic;
using SocialNetwork.Profile.UnitOfWorks;
using SocialNetwork.Profile.BusinessObjects;

namespace SocialNetwork.Profile.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IProfileUnitOfWork _profileUnitOfWork;

        public PhotoService(IProfileUnitOfWork profileUnitOfWork)
        {
            _profileUnitOfWork = profileUnitOfWork;
        }

        public void CreatePhoto(Photo photo)
        {
            _profileUnitOfWork.PhotoRepository.Add(
                new Entities.Photo
                {
                    MemberId = photo.MemberId, 
                    PhotoFileName = photo.PhotoFileName
                }
            );

            _profileUnitOfWork.Save();
        }

        public void DeletePhoto(int photoId)
        {
            _profileUnitOfWork.PhotoRepository.Remove(photoId);
            _profileUnitOfWork.Save();
        }

        public IList<Photo> GetAllPhotos()
        {
            var photoEntities = _profileUnitOfWork.PhotoRepository.GetAll();
            var photos = new List<Photo>();

            foreach (var entity in photoEntities)
            {
                photos.Add(new Photo
                {
                    Id = entity.Id,
                    MemberId = entity.MemberId,
                    PhotoFileName = entity.PhotoFileName
                });
            }

            return photos;
        }

        public Photo GetPhoto(int id)
        {
            var photo = _profileUnitOfWork.PhotoRepository.GetById(id);

            if (photo == null) return null;

            return new Photo
            {
                Id = photo.Id,
                MemberId = photo.MemberId,
                PhotoFileName = photo.PhotoFileName
            };
        }

        public (IList<Photo> records, int total, int totalDisplay) GetPhotos(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var photoData = _profileUnitOfWork.PhotoRepository.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.MemberId.ToString().Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize); ;

            var result = (from photo in photoData.data
                          select new Photo
                          {
                              Id = photo.Id,
                              MemberId = photo.MemberId,
                              PhotoFileName = photo.PhotoFileName
                          }).ToList();

            return (result, photoData.total, photoData.totalDisplay);
        }

        public void UpdatePhoto(Photo photo)
        {
            if (photo == null) throw new InvalidOperationException("Photo is messing");

            var photoEntity = _profileUnitOfWork.PhotoRepository.GetById(photo.Id);

            if(photoEntity != null)
            {
                photoEntity.MemberId = photo.MemberId;
                photoEntity.PhotoFileName = photo.PhotoFileName;
                _profileUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find photo");
            }
        }
    }
}
