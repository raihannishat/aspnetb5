using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Data;
using DataImporter.Library.Contexts;
using DataImporter.Library.Repositories;

namespace DataImporter.Library.UnitOfWorks
{
    public class DataImporterUnitOfWork : UnitOfWork, IDataImporterUnitOfWork
    {
        public DataImporterUnitOfWork(IDataImporterDbContext dbContext,
            IExcelRowRepository excelRowRepository,
            IExcelColumnRepository excelColumnRepository,
            IImportExcelFileRepository importExcelFileRepository,
            IExportExcelFileRepository exportExcelFileRepository,
            IGroupRepository groupRepository)
            : base((Context)dbContext)
        {
            ExcelColumnRepository = excelColumnRepository;
            ExcelRowRepository = excelRowRepository;
            ExportExcelFileRepository = exportExcelFileRepository;
            ImportExcelFileRepository = importExcelFileRepository;
            GroupRepository = groupRepository;
        }

        public IExcelColumnRepository ExcelColumnRepository { get; private set; }
        public IExcelRowRepository  ExcelRowRepository { get; private set; }
        public IExportExcelFileRepository ExportExcelFileRepository { get; private set; }
        public IImportExcelFileRepository ImportExcelFileRepository { get; private set; }
        public IGroupRepository GroupRepository { get; private set; }
    }
}
