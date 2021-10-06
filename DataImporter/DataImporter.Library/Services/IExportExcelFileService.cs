using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Library.BusinessObjects;

namespace DataImporter.Library.Services
{
    public interface IExportExcelFileService
    {
        void CreateExportExcelFile(ExportExcelFile exportExcelFile);
        (IList<ExportExcelFile> records, int total, int totalDisplay)
            GetExportExcelFiles(int pageIndex, int pageSize, string searchText, string sortText);
        ExportExcelFile GetExportExcelFile(int id);
        void UpdateExportExcelFile(ExportExcelFile exportExcelFile);
        void DeleteExportExcelFile(int exportExcelFileId);
    }
}
