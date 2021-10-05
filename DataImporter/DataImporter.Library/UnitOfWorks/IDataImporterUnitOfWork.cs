using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Data;
using DataImporter.Library.Repositories;

namespace DataImporter.Library.UnitOfWorks
{
    public interface IDataImporterUnitOfWork : IUnitOfWork
    {
        IExcelColumnRepository ExcelColumnRepository { get; }
        IExcelRowRepository ExcelRowRepository { get; }
        IExportExcelFileRepository ExportExcelFileRepository { get; }
        IImportExcelFileRepository ImportExcelFileRepository { get; }
        IGroupRepository GroupRepository { get; }
    }
}
