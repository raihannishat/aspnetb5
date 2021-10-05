using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Library.BusinessObjects
{
    public class ExcelRow
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
