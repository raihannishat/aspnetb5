using System;

namespace ActionDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = ShowMessage;
            action.Invoke("Hello World!");
        }

        static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
