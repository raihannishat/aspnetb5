using System;
using System.Threading;
using System.IO;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            var thread1 = new Thread(new ThreadStart(WriteFile));
            var thread2 = new Thread(new ThreadStart(WriteFile));

            thread1.Start(); 
            thread2.Start();

            int x = 5;

            lock (thread1)
            {
                x++;
            }
        }

        static void PrintNumber1()
        {
            for (int i = 0; i < 100; i += 2)
            {
                Console.WriteLine($"Number : {i}");
                Thread.Sleep(500);
            }
        }

        static void PrintNumber2()
        {
            for (int i = 1; i < 100; i += 2)
            {
                Console.WriteLine($"Number : {i}");
                Thread.Sleep(500);
            }
        }

        static void WriteFile()
        {
            var path = @"D:\Code\GitHub\aspnetb5\C_Sharp_Code\Threads\File.txt";

            lock (path)
            {
                File.AppendAllText(path, "Hello ");
            }
        }
    }
}
