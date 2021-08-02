using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using SocialNetwork.Profile.Services;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.Areas.Admin.Models
{
    public class PhotoListModel
    {
        private readonly IPhotoService _photoService;

        public PhotoListModel()
        {
            _photoService = Startup.AutofacContainer.Resolve<IPhotoService>();
        }

        public PhotoListModel(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public object GetPhotos(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _photoService.GetPhotos(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                dataTablesModel.GetSortText(new string[] { "MemberId", "PhotoFileName" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.MemberId.ToString(),
                            record.PhotoFileName,
                            record.Id.ToString()
                        }
                ).ToArray()
            };
        }

        public void Delete(int id)
        {
            _photoService.DeletePhoto(id);
        }
    }
}
