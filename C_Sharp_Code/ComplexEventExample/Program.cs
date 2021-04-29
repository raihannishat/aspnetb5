using System;

namespace ComplexEventExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var reg = new RandomEventGenerator();
            reg.Generate();
        }
    }
}
