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
    public class ImportExcelFileService : IImportExcelFileService
    {
        private readonly IDataImporterUnitOfWork _dataImporterUnitOfWork;
        private readonly IMapper _mapper;

        public ImportExcelFileService(IDataImporterUnitOfWork dataImporterUnitOfWork, IMapper mapper)
        {
            _dataImporterUnitOfWork = dataImporterUnitOfWork;
            _mapper = mapper;
        }

        public void CreateImportExcelFile(ImportExcelFile importExcelFile)
        {
            _dataImporterUnitOfWork
                .ImportExcelFileRepository
                .Add(_mapper.Map<Entities.ImportExcelFile>(importExcelFile));

            _dataImporterUnitOfWork.Save();
        }

        public void DeleteImportExcelFile(int importExcelFileId)
        {
            _dataImporterUnitOfWork
                .ImportExcelFileRepository
                .Remove(importExcelFileId);

            _dataImporterUnitOfWork.Save();
        }

        public IList<Entities.ImportExcelFile> GetAllImportExcelFile()
        {
            return _dataImporterUnitOfWork.ImportExcelFileRepository.GetAll();
        }

        public ImportExcelFile GetImportExcelFile(int id)
        {
            var importExcelFile = _dataImporterUnitOfWork
                .ImportExcelFileRepository
                .GetById(id);

            if (importExcelFile == null) return null;

            return _mapper.Map<ImportExcelFile>(importExcelFile);
        }

        public (IList<ImportExcelFile> records, int total, int totalDisplay) 
            GetImportExcelFiles(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var teamData = _dataImporterUnitOfWork
                .ImportExcelFileRepository
                .GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null :
                x => x.ImportStatus.Contains(searchText), sortText, string.Empty, pageIndex, pageSize);

            var result = (from importFile in teamData.data
                          select _mapper.Map<ImportExcelFile>(importFile)).ToList();

            return (result, teamData.total, teamData.totalDisplay);
        }

        public void UpdateImportExcelFile(ImportExcelFile importExcelFile)
        {
            var importExcelFileEntity = _dataImporterUnitOfWork
                .ImportExcelFileRepository
                .GetById(importExcelFile.Id);

            if (importExcelFileEntity != null)
            {
                _mapper.Map(importExcelFile, importExcelFileEntity);
                _dataImporterUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find ImportExcelFile");
            }
        }
    }
}
