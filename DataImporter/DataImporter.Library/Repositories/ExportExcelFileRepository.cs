using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Data;
using DataImporter.Library.Entities;
using DataImporter.Library.Contexts;

namespace DataImporter.Library.Repositories
{
    public class ExportExcelFileRepository : Repository<ExportExcelFile, int>, IExportExcelFileRepository
    {
        public ExportExcelFileRepository(IDataImporterDbContext context) : base((Context)context)
        {

        }
    }
}
