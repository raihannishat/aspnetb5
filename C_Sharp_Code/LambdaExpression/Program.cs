using System;
using System.Linq;
using System.Collections.Generic;

namespace LambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func<int, int> square = x => x * x;
            //Func<int, int> cube = x => x * x * x;
            //Func<int, int> inc = x => x++;
            //Func<int, int, int> add = (x, y) => x + y;

            //Console.WriteLine(square(5));
            //Console.WriteLine(cube(5));
            //Console.WriteLine(inc(5));
            //Console.WriteLine(add(5, 7));

            //Action<string> greet = name =>
            //{
            //    string greeting = $"Hello {name}!";
            //    Console.WriteLine(greeting);
            //};

            //greet.Invoke("Pau");
            //greet.Invoke("Lucia");

            //int[] vals = { 1, -2, 3, 4, 0, -3, 2, 1, 3 };
            //var v1 = Array.FindIndex(vals, x => x == 3);
            //Console.WriteLine(v1);

            //var v2 = Array.FindLastIndex(vals, x => x == 3);
            //Console.WriteLine(v2);

            //var positive = Array.FindAll(vals, x => x > 0);
            //Console.WriteLine(string.Join(", ", positive));

            //var vals = new List<int> { -1, 2, -2, 0, 3, 4, -5 };
            //var squared = vals.Select(x => x * x);
            //Console.WriteLine(string.Join(", ", squared));

            //var filtered = vals.Where(x => x > 0);
            //Console.WriteLine(string.Join(", ", filtered));

            //var funs = new Func<int, int>[]
            //{
            //    x => x * x,
            //    x => ++x,
            //    x => --x
            //};

            //for (int i = 0; i < 6; i++)
            //{
            //    Console.WriteLine(funs[0](i));
            //    Console.WriteLine(funs[1](i));
            //    Console.WriteLine(funs[2](i));
            //    Console.WriteLine();
            //}


        }
    }
}
