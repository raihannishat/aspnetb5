using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Question_2
{
    public class ReflectionUtility<T> where T : class
    {
        public void GetPrivateAndProtectedMethods()
        {
            var type = typeof(T);
            var constructorInfo = type.GetConstructor(new Type[0]);
            var instance = constructorInfo.Invoke(new object[0]);
            var methodInfos = type.GetMethods(BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance);

            var methods = (from method in methodInfos
                           where method.IsPrivate || method.IsFamily
                           select method).ToList();

            for (int i = 0; i < methods.Count; i++)
            {
                Console.WriteLine($"({i + 1}) : {methods[i].Name}");
            }

            Console.WriteLine("=====================");

            Console.Write("Select an option : ");
            var option = int.Parse(Console.ReadLine());
            methods[option - 1].Invoke(instance, new object[0]);
        }
    }
}
