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
            IContentRepository contentRepository,
            IExcelFileRepository excelFileRepository,
            IGroupRepository groupRepository)
            : base((Context)dbContext)
        {
            ContentRepository = contentRepository;
            ExcelFileRepository = excelFileRepository;
            GroupRepository = groupRepository;
        }

        public IContentRepository ContentRepository { get; private set; }
        public IExcelFileRepository ExcelFileRepository { get; private set; }
        public IGroupRepository GroupRepository { get; private set; }
    }
}
