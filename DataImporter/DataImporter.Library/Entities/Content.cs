using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Data;

namespace DataImporter.Library.Entities
{
    public class Content : IEntity<int>
    {
        public int Id { get; set; }
        public string Field { get; set; }
        public object Value { get; set; }
        public int ExcelFileId { get; set; }
    }
}
