using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaihanFrameworkCore;

namespace Test
{
    public class Students : IData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? CGPA { get; set; }
    }
}
