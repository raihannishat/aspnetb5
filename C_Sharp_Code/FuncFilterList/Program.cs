using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncFilterList
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<Person>
            {
                new Person("John Doe", "gardener"),
                new Person("Robert Brown", "programmer"),
                new Person("Lucia Smith", "teacher"),
                new Person("Thomas Neuwirth", "teacher")
            };

            ShowOutput(data, r => r.Occupation == "teacher");
        }

        static void ShowOutput(List<Person> list, Func<Person, bool> condition)
        {
            var data = list.Where(condition);

            foreach (var person in data)
            {
                Console.WriteLine("{0}, {1}", person.Name, person.Occupation);
            }
        }
    }

    record Person(string Name, string Occupation);
}
