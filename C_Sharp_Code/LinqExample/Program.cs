using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExample
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string[] names = { "Jamal", "Kamal", "Asif", "Raihan" };

            var myQuery = from name in names
                          where name.EndsWith('l')
                          select name;

            var myNewQuery = names.Where(x => x.EndsWith('l'));

            foreach (var item in myNewQuery)
            {
                Console.WriteLine(item);
            }
            */

            var studentList = new List<Student>()
            {
                new Student(){ Name = "Jamal", Roll = 103, CGPA = 3.25 },
                new Student(){ Name = "Kamal", Roll = 102, CGPA = 3.50 },
                new Student(){ Name = "Asif", Roll = 103, CGPA = 3.15 },
                new Student(){ Name = "Raihan", Roll = 104, CGPA = 3.00 }
            };

            var myList = from item in studentList
                         where item.Roll == 103 && item.Name.Contains('A')
                         select item;

            var myLamda = studentList.Where(x => x.Roll == 103 && x.Name.Contains('a')).ToList();

            var myNewLamda = studentList.Where(x => x.CGPA <= 3.20).ToList();

            var avaGpa = studentList.Average(x => x.CGPA);

            Console.WriteLine($"{avaGpa:f2}");

            foreach (var student in myNewLamda)
            {
                Console.WriteLine($"{student.Name} {student.CGPA:f2}");
            }
        }
    }
}
