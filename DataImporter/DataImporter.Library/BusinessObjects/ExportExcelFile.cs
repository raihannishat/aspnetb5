using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Library.BusinessObjects
{
    public class ExportExcelFile
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int GroupId { get; set; }
        public DateTime ExportDate { get; set; }
    }
}
