using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Data;
using DataImporter.Membership.Entities;

namespace DataImporter.Library.Entities
{
    public class ExcelRow : IEntity<int>
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public DateTime UploadDate { get; set; }
        public List<ExcelColumn> ExcelColumns { get; set; }
    }
}
