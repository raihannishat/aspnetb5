using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Store.Contexts
{
    public abstract class Context : DbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public Context(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(_connectionString, 
                    m => m.MigrationsAssembly(_migrationAssembly));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }
    }
}
