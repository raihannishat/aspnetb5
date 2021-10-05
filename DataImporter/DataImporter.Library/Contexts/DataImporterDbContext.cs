using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataImporter.Library.Entities;
using DataImporter.Membership.Entities;

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
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("AspNetUsers", t => t.ExcludeFromMigrations())
                .HasMany<Group>()
                .WithOne(au => au.ApplicationUser);

            modelBuilder.Entity<Group>()
                .HasMany(ief => ief.ImportExcelFiles)
                .WithOne(gp => gp.Group);

            modelBuilder.Entity<Group>()
                .HasMany(eef => eef.ExportExcelFiles)
                .WithOne(gp => gp.Group);

            modelBuilder.Entity<Group>()
                .HasMany(er => er.ExcelRows)
                .WithOne(gp => gp.Group);

            modelBuilder.Entity<ExcelRow>()
                .HasMany(ec => ec.ExcelColumns)
                .WithOne(er => er.ExcelRow);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<ImportExcelFile> ImportExcelFiles { get; set; }
        public DbSet<ExportExcelFile> ExportExcelFiles { get; set; }
        public DbSet<ExcelRow> ExcelRows { get; set; }
        public DbSet<ExcelColumn> ExcelColumns { get; set; }
    }
}
