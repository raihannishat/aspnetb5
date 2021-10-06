using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Library.BusinessObjects;

namespace DataImporter.Library.Services
{
    public interface IExcelRowService
    {
        void CreateExcelRow(ExcelRow excelRow);
        (IList<ExcelRow> records, int total, int totalDisplay)
            GetExcelRows(int pageIndex, int pageSize, string searchText, string sortText);
        ExcelRow GetExcelRow(int id);
        void UpdateExcelRow(ExcelRow excelRow);
        void DeleteExcelRow(int excelRowId);
    }
}
