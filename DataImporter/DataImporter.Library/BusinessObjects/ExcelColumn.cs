using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Library.BusinessObjects
{
    public class ExcelColumn
    {
        public int Id { get; set; }
        public string Column { get; set; }
        public string Value { get; set; }
        public int ExcelFileId { get; set; }
    }
}
