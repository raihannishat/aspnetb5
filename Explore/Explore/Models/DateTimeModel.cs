using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Explore.Models
{
    public class DateTimeModel
    {
        public DateTime MyDateTime { get; set; }

        public DateTimeModel()
        {
            MyDateTime = DateTime.Now;
        }
    }
}
