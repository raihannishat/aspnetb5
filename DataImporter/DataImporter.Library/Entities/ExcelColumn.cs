using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Data;

namespace DataImporter.Library.Entities
{
    public class ExcelColumn : IEntity<int>
    {
        public int Id { get; set; }
        public string Column { get; set; }
        public string Value { get; set; }
        public int ExcelRowId { get; set; }
        public ExcelRow ExcelRow { get; set; }
    }
}
