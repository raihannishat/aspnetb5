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
    public class ExcelColumnService : IExcelColumnService
    {
        private readonly IDataImporterUnitOfWork _dataImporterUnitOfWork;
        private readonly IMapper _mapper;

        public ExcelColumnService(IDataImporterUnitOfWork dataImporterUnitOfWork, IMapper mapper)
        {
            _dataImporterUnitOfWork = dataImporterUnitOfWork;
            _mapper = mapper;
        }

        public void CreateExcelColumn(ExcelColumn excelColumn)
        {
            _dataImporterUnitOfWork
                .ExcelColumnRepository
                .Add(_mapper.Map<Entities.ExcelColumn>(excelColumn));

            _dataImporterUnitOfWork.Save();
        }

        public void DeleteExcelColumn(int excelColumnId)
        {
            _dataImporterUnitOfWork
                .ExcelColumnRepository
                .Remove(excelColumnId);
            
            _dataImporterUnitOfWork.Save();
        }

        public ExcelColumn GetExcelColumn(int id)
        {
            var excelColumn = _dataImporterUnitOfWork
                .ExcelColumnRepository
                .GetById(id);

            if (excelColumn == null) return null;

            return _mapper.Map<ExcelColumn>(excelColumn);
        }

        public (IList<ExcelColumn> records, int total, int totalDisplay) 
            GetExcelColumns(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var teamData = _dataImporterUnitOfWork.ExcelColumnRepository
                .GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null : 
                x => x.Value.Contains(searchText), sortText, string.Empty, pageIndex, pageSize);

            var result = (from column in teamData.data
                          select _mapper.Map<ExcelColumn>(column)).ToList();

            return (result, teamData.total, teamData.totalDisplay);
        }

        public void UpdateExcelColumn(ExcelColumn excelColumn)
        {
            var excelColumnEntity = _dataImporterUnitOfWork
                .ExcelColumnRepository
                .GetById(excelColumn.Id);

            if (excelColumnEntity != null)
            {
                _mapper.Map(excelColumn, excelColumnEntity);
                _dataImporterUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find ExcelColumn");
            }
        }
    }
}
