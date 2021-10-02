using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Data;
using DataImporter.Membership.Entities;

namespace DataImporter.Library.Entities
{
    public class Group : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<ExcelFile> ExcelFiles { get; set; }
        public List<History> Histories { get; set; }
    }
}
