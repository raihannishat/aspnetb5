using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using SocialNetwork.Profile.BusinessObjects;
using SocialNetwork.Profile.Services;

namespace SocialNetwork.Web.Areas.Admin.Models
{
    public class CreatePhotoModel
    {
        public int MemberId { get; set; }
        [Required, MaxLength(200, ErrorMessage = "PhotoFileName shoul be less than 200 characters")]
        public string PhotoFileName { get; set; }

        private readonly IPhotoService _photoService;

        public CreatePhotoModel()
        {
            _photoService = Startup.AutofacContainer.Resolve<IPhotoService>();
        }

        public CreatePhotoModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public void Create()
        {
            _photoService.CreatePhoto(new Photo
            {
                MemberId = MemberId,
                PhotoFileName = PhotoFileName
            });
        }
    }
}
