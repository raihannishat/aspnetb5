using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Library.Services;
using Autofac;

namespace DataImporter.Worker.Model
{
    public class WorkerModel
    {
        private readonly IImportExcelFileService _importExcelFileService;

        public WorkerModel()
        {
            _importExcelFileService = Worker.AutofacContainer.Resolve<IImportExcelFileService>();
        }

        public void Import()
        {
            _importExcelFileService.ImportExcelFile();
        }
    }
}
