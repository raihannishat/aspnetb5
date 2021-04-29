using System;
using System.IO;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\Code\GitHub\aspnetb5\C_Sharp_Code\Reflection\config.txt";
            var configText = File.ReadAllText(path);
            var initClassName = configText.Split('=')[1].Trim();

            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var item in types)
            {
                if (item.Name.Equals(initClassName))
                {
                    var constructor = item.GetConstructor(new Type[] { typeof(int), typeof(int) });
                    var instance = constructor.Invoke(new object[] { 5, 6 });
                    var method = item.GetMethod("InitStartUp");
                    method.Invoke(instance, new object[0]);
                }
            }

            //Type type = typeof(Product);

            //foreach (var item in type.GetProperties())
            //{
            //    Console.WriteLine(item.Name);
            //}
        }
    }
}
