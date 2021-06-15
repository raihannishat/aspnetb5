using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salesforce.Data
{
    public class TestDbContext : SalesForceDbContext
    {
        public TestDbContext(string connectionString, string migrationAssemblyName)
            : base(connectionString, migrationAssemblyName)
        {

        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
