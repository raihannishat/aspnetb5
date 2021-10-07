using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataImporter.Core;
using DataImporter.Library.BusinessObjects;
using DataImporter.Library.Services;
using Autofac;
using AutoMapper;

namespace DataImporter.Web.Models.Imports
{
    public class CreateImportModel
    {
        public int GroupId { get; set; }
        public string Location { get; set; }
        public DateTime ImportDate { get; set; }
        public string ImportStatus { get; set; }

        private readonly IImportExcelFileService _importExcelFileService;
        private readonly IMapper _mapper;

        public CreateImportModel()
        {
            _importExcelFileService = Startup.AutofacContainer.Resolve<IImportExcelFileService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public CreateImportModel(IImportExcelFileService importExcelFileService)
        {
            _importExcelFileService = importExcelFileService;
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public void Create()
        {
            _importExcelFileService.CreateImportExcelFile(
                new ImportExcelFile 
                {
                    GroupId = GroupId, 
                    Location = Location,
                    ImportDate = ImportDate,
                    ImportStatus = ImportStatus
                });
        }
    }
}
