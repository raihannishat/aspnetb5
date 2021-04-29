using System;
using System.Collections.Generic;

namespace PredicateDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> vals = new List<int> { 4, 2, 3, 0, 6, 7, 1, 9 };

            Predicate<int> predicate = greaterThanThree;

            List<int> vals2 = vals.FindAll(predicate);

            foreach (var item in vals2)
            {
                Console.WriteLine(item);
            }
        }

        static bool greaterThanThree(int x)
        {
            return x > 3;
        }
    }
}
