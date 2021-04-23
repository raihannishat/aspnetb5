using System;
using System.Reflection;

namespace Question_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = typeof(BaseModel);

            foreach (var item in assembly.GetTypes())
            {
                if (item.BaseType.Name == type.Name)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
}
