using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    public class Calculator
    {
        // public delegate void myDelegate(int a, int b);

        public int Sub(int x, int y)
        {
            Console.WriteLine($"Sub : {x - y}");
            return x - y;
        }

        public int Sum(int x, int y)
        {
            Console.WriteLine($"Sum : {x + y}");
            return x + y;
        }

        public int Mul(int x, int y)
        {
            Console.WriteLine($"Sub : {x * y}");
            return x * y;
        }
    }
}
