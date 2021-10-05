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
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<ImportExcelFile> ImportExcelFiles { get; set; }
        public List<ExportExcelFile> ExportExcelFiles { get; set; }
        public List<ExcelRow> ExcelRows { get; set; }
    }
}
