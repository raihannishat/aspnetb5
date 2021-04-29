using System;

namespace FuncDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string> func = GetMessage;
            Console.WriteLine(func.Invoke());
        }

        static string GetMessage()
        {
            return "Hello World!";
        }
    }
}
