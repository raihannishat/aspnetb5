using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataImporter.Library.Entities;

namespace DataImporter.Library.Contexts
{
    public class DataImporterDbContext : Context, IDataImporterDbContext
    {
        public DataImporterDbContext(string connectionString, string migrationAssembly)
            : base(connectionString, migrationAssembly)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Content> Contents { get; set; }
        public DbSet<ExcelFile> ExcelFiles { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
