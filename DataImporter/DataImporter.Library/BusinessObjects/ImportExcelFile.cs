using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Library.BusinessObjects
{
    public class ImportExcelFile
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public Guid UserId { get; set; }
        public string Location { get; set; }
        public DateTime ImportDate { get; set; }
        public string ImportStatus { get; set; }
    }
}
