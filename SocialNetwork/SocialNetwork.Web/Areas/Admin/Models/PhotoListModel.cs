using Autofac;
using System.Linq;
using SocialNetwork.Web.Models;
using SocialNetwork.Profile.Services;

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
                dataTablesModel.GetSortText(new string[] { "Id", "MemberId", "PhotoFileName" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Id.ToString(),
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
