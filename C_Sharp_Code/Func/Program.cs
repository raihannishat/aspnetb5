using System;

namespace Func
{
    class Program
    {
        static void Main(string[] args)
        {
            //Func<string> sayHello = GetMessage;
            //Console.WriteLine(sayHello.Invoke());

            Func<int, int, int, int> add = Sum;

            Console.WriteLine(add.Invoke(150, 210, 360));
        }

        static int Sum(int x, int y, int z)
        {
            return x + y + z;
        }

        //static string GetMessage()
        //{
        //    return "Hello there!";
        //}
    }
}
