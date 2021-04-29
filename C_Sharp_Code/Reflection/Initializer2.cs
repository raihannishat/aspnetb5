using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Initializer2
    {
        public Initializer2(int val1, int val2)
        {
            Console.WriteLine($"Ctor : {val1}, {val2}");
        }

        public void InitStartUp()
        {
            Console.WriteLine("Starting initializer in setup 2");
        }
    }
}
