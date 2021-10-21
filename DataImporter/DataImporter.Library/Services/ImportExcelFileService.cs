using AutoMapper;
using DataImporter.Library.BusinessObjects;
using DataImporter.Library.UnitOfWorks;
using GemBox.Spreadsheet;
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

        public ImportExcelFileService(IDataImporterUnitOfWork dataImporterUnitOfWork)
        {
            _dataImporterUnitOfWork = dataImporterUnitOfWork;
        }

        public void ImportExcelFile()
        {
            var status = GetAllImportExcelFile();
            string filePath = null;
            var rows = new BusinessObjects.ExcelRow();
            var columns = new BusinessObjects.ExcelColumn();

            foreach (var item in status)
            {
                if (item.ImportStatus.Equals("Working"))
                {
                    filePath = item.Location;
                    rows.GroupId = item.GroupId;
                    rows.UploadDate = item.ImportDate;
                    item.ImportStatus = "Success";
                    
                    _dataImporterUnitOfWork.ExcelRowRepository.Add(new Entities.ExcelRow
                    {
                        GroupId = rows.GroupId,
                        UploadDate = rows.UploadDate
                    });
                    
                    _dataImporterUnitOfWork.Save();
                }
                else
                {
                    continue;
                }

                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                var workbook = ExcelFile.Load(filePath);
                var list = new List<string>();

                var entity = _dataImporterUnitOfWork
                                    .ExcelRowRepository.GetAll()
                                    .OrderBy(x => 
                                        x.UploadDate == rows.UploadDate && 
                                        x.GroupId == rows.GroupId)
                                    .FirstOrDefault();

                foreach (var worksheet in workbook.Worksheets)
                {
                    int count = 0;

                    foreach (var row in worksheet.Rows)
                    {
                        foreach (var cell in row.AllocatedCells)
                        {
                            if (row.Name == "1")
                            {
                                list.Add(cell.Value.ToString());
                            }
                            else if (cell.ValueType != CellValueType.Null)
                            {
                                columns.ExcelRowId = entity.Id;
                                columns.Column = list[count++];
                                columns.Value = cell.Value.ToString();

                                _dataImporterUnitOfWork.ExcelColumnRepository.Add(new Entities.ExcelColumn
                                {
                                    ExcelRowId = columns.ExcelRowId,
                                    Column = columns.Column,
                                    Value = columns.Value
                                });

                                _dataImporterUnitOfWork.Save();
                            }
                        }

                        count = 0;
                    }
                }

                // _dataImporterUnitOfWork.Save();
            }
        }

        public void CreateImportExcelFile(ImportExcelFile importExcelFile)
        {
            //_dataImporterUnitOfWork
            //    .ImportExcelFileRepository
            //    .Add(_mapper.Map<Entities.ImportExcelFile>(importExcelFile));

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

            // return _mapper.Map<ImportExcelFile>(importExcelFile);
            return new ImportExcelFile();
        }

        public (IList<ImportExcelFile> records, int total, int totalDisplay) 
            GetImportExcelFiles(int pageIndex, int pageSize, string searchText, string sortText, Guid userId)
        {
            var teamData = _dataImporterUnitOfWork.ImportExcelFileRepository
                .GetDynamic(string.IsNullOrWhiteSpace(searchText) ? 
                x => x.Group.ApplicationUserId == userId :
                x => x.ImportStatus.Contains(searchText), sortText, string.Empty, pageIndex, pageSize);

            //var result = (from importFile in teamData.data
            //              select _mapper.Map<ImportExcelFile>(importFile)).ToList();

            return (new List<ImportExcelFile>(), teamData.total, teamData.totalDisplay);
        }

        public void UpdateImportExcelFile(ImportExcelFile importExcelFile)
        {
            var importExcelFileEntity = _dataImporterUnitOfWork
                .ImportExcelFileRepository
                .GetById(importExcelFile.Id);

            if (importExcelFileEntity != null)
            {
                //_mapper.Map(importExcelFile, importExcelFileEntity);
                _dataImporterUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find ImportExcelFile");
            }
        }
    }
}
