using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using DataImporter.Core;
using DataImporter.Library.Services;
using Microsoft.AspNetCore.Http;

namespace DataImporter.Web.Models.Imports
{
    public class ImportListModel
    {
        private readonly IImportExcelFileService _importExcelFileService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ImportListModel()
        {
            _importExcelFileService = Startup.AutofacContainer.Resolve<IImportExcelFileService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }

        public ImportListModel(IImportExcelFileService importExcelFileService,
            IHttpContextAccessor httpContextAccessor)
        {
            _importExcelFileService = importExcelFileService;
            _httpContextAccessor = httpContextAccessor;
        }

        public object GetImpots(DataTablesAjaxRequestModel tableModel)
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext.User
                        .FindFirst(ClaimTypes.NameIdentifier).Value);

            var data = _importExcelFileService.GetImportExcelFiles(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Id", "Name" }), userId);

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Id.ToString(),
                            record.GroupId.ToString(),
                            record.Location.ToString(),
                            record.ImportDate.ToString(),
                            record.ImportStatus.ToString(),
                            record.Id.ToString()
                        }
                ).ToArray()
            };
        }

        public void Delete(int id)
        {
            _importExcelFileService.DeleteImportExcelFile(id);
        }
    }
}
