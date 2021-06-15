using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salesforce.Data
{
    public class House
    {
        public int Id { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
