using System;

namespace FuncWithLambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> randInt = (n1, n2) => new Random().Next(n1, n2);
            Console.WriteLine(randInt.Invoke(1, 100));
        }
    }
}
