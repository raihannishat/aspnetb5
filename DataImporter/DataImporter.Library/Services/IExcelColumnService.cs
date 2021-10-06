using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Library.BusinessObjects;

namespace DataImporter.Library.Services
{
    public interface IExcelColumnService
    {
        void CreateExcelColumn(ExcelColumn excelColumn);
        (IList<ExcelColumn> records, int total, int totalDisplay)
            GetExcelColumns(int pageIndex, int pageSize, string searchText, string sortText);
        ExcelColumn GetExcelColumn(int id);
        void UpdateExcelColumn(ExcelColumn excelColumn);
        void DeleteExcelColumn(int excelColumnId);
    }
}
