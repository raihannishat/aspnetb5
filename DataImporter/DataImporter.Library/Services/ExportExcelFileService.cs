using AutoMapper;
using DataImporter.Library.BusinessObjects;
using DataImporter.Library.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Library.Services
{
    public class ExportExcelFileService : IExportExcelFileService
    {
        private readonly IDataImporterUnitOfWork _dataImporterUnitOfWork;
        private readonly IMapper _mapper;

        public ExportExcelFileService(IDataImporterUnitOfWork dataImporterUnitOfWork, IMapper mapper)
        {
            _dataImporterUnitOfWork = dataImporterUnitOfWork;
            _mapper = mapper;
        }

        public void CreateExportExcelFile(ExportExcelFile exportExcelFile)
        {
            _dataImporterUnitOfWork
                .ExportExcelFileRepository
                .Add(_mapper.Map<Entities.ExportExcelFile>(exportExcelFile));

            _dataImporterUnitOfWork.Save();
        }

        public void DeleteExportExcelFile(int exportExcelFileId)
        {
            _dataImporterUnitOfWork
                .ExportExcelFileRepository
                .Remove(exportExcelFileId);

            _dataImporterUnitOfWork.Save();
        }

        public ExportExcelFile GetExportExcelFile(int id)
        {
            var exportExcelFile = _dataImporterUnitOfWork
                .ExportExcelFileRepository
                .GetById(id);

            if (exportExcelFile == null) return null;

            return _mapper.Map<ExportExcelFile>(exportExcelFile);
        }

        public (IList<ExportExcelFile> records, int total, int totalDisplay) 
            GetExportExcelFiles(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var teamData = _dataImporterUnitOfWork.ExportExcelFileRepository.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : 
                x => x.ExportDate.ToString().Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var result = (from exportFile in teamData.data
                          select _mapper.Map<ExportExcelFile>(exportFile)).ToList();

            return (result, teamData.total, teamData.totalDisplay);
        }

        public void UpdateExportExcelFile(ExportExcelFile exportExcelFile)
        {
            var exportExcelFileEntity = _dataImporterUnitOfWork.
                ExportExcelFileRepository.
                GetById(exportExcelFile.Id);

            if (exportExcelFileEntity != null)
            {
                _mapper.Map(exportExcelFile, exportExcelFileEntity);
                _dataImporterUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find ExportExcelFile");
            }
        }
    }
}
