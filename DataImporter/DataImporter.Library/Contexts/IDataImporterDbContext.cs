using DataImporter.Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataImporter.Library.Contexts
{
    public interface IDataImporterDbContext
    {
        DbSet<Content> Contents { get; set; }
        DbSet<ExcelFile> ExcelFiles { get; set; }
        DbSet<Group> Groups { get; set; }
    }
}