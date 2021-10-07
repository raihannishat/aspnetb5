using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DataImporter.Core;
using DataImporter.Library.Services;

namespace DataImporter.Web.Models.Imports
{
    public class ImportListModel
    {
        private readonly IImportExcelFileService _importExcelFileService;

        public ImportListModel()
        {
            _importExcelFileService = Startup.AutofacContainer.Resolve<IImportExcelFileService>();
        }

        public ImportListModel(IImportExcelFileService importExcelFileService)
        {
            _importExcelFileService = importExcelFileService;
        }

        public object GetImpots(DataTablesAjaxRequestModel tableModel)
        {
            var data = _importExcelFileService.GetImportExcelFiles(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Id", "Name" }));

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
