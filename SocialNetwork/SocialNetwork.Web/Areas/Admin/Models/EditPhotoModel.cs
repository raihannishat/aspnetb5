using Autofac;
using SocialNetwork.Profile.Services;
using SocialNetwork.Profile.BusinessObjects;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Web.Areas.Admin.Models
{
    public class EditPhotoModel
    {
        public int? Id { get; set; }
        public int? MemberId { get; set; }
        [Required, MaxLength(200, ErrorMessage = "PhotoFileName shoul be less than 200 characters")]
        public string PhotoFileName { get; set; }

        private readonly IPhotoService _photoService;

        public EditPhotoModel()
        {
            _photoService = Startup.AutofacContainer.Resolve<IPhotoService>();
        }

        public void LoadModelData(int id)
        {
            var photo = _photoService.GetPhoto(id);
            Id = photo?.Id;
            MemberId = photo?.MemberId;
            PhotoFileName = photo?.PhotoFileName;
        }

        public void Update()
        {
            _photoService.UpdatePhoto(new Photo
            {
                Id = Id.HasValue ? Id.Value : 0,
                MemberId = MemberId.HasValue ? MemberId.Value : 0,
                PhotoFileName = PhotoFileName
            });
        }
    }
}
