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
    public class ExcelRowService : IExcelRowService
    {
        private readonly IDataImporterUnitOfWork _dataImporterUnitOfWork;
        private readonly IMapper _mapper;

        public ExcelRowService(IDataImporterUnitOfWork dataImporterUnitOfWork, IMapper mapper)
        {
            _dataImporterUnitOfWork = dataImporterUnitOfWork;
            _mapper = mapper;
        }

        public void CreateExcelRow(ExcelRow excelRow)
        {
            _dataImporterUnitOfWork
                .ExcelRowRepository
                .Add(_mapper.Map<Entities.ExcelRow>(excelRow));

            _dataImporterUnitOfWork.Save();
        }

        public void DeleteExcelRow(int excelRowId)
        {
            _dataImporterUnitOfWork
                .ExcelRowRepository
                .Remove(excelRowId);
            
            _dataImporterUnitOfWork.Save();
        }

        public ExcelRow GetExcelRow(int id)
        {
            var row = _dataImporterUnitOfWork
                .ExcelRowRepository
                .GetById(id);

            if (row == null) return null;

            return _mapper.Map<ExcelRow>(row);
        }

        public (IList<ExcelRow> records, int total, int totalDisplay) 
            GetExcelRows(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var teamData = _dataImporterUnitOfWork.ExcelRowRepository.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : 
                x => x.GroupId.ToString().Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var result = (from row in teamData.data
                          select _mapper.Map<ExcelRow>(row)).ToList();

            return (result, teamData.total, teamData.totalDisplay);
        }

        public void UpdateExcelRow(ExcelRow excelRow)
        {
            var excelRowEntity = _dataImporterUnitOfWork
                .ExcelRowRepository
                .GetById(excelRow.Id);

            if (excelRowEntity != null)
            {
                _mapper.Map(excelRow, excelRowEntity);
                _dataImporterUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find ExcelRow");
            }
        }
    }
}
