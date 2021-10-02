using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Library.BusinessObjects
{
    public class History
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public Guid UserId { get; set; }
    }
}
