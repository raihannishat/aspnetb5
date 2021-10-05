using DataImporter.Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataImporter.Library.Contexts
{
    public interface IDataImporterDbContext
    {
        DbSet<Group> Groups { get; set; }
        DbSet<ImportExcelFile> ImportExcelFiles { get; set; }
        DbSet<ExportExcelFile> ExportExcelFiles { get; set; }
        DbSet<ExcelRow> ExcelRows { get; set; }
        DbSet<ExcelColumn> ExcelColumns { get; set; }
    }
}