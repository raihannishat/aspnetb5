using System;
using System.Linq;
using System.Collections.Generic;

namespace Question_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> list1 = new List<Student>
            {
                new Student() { Name = "Raihan", Age = 24 },
                new Student() { Name = "Asif", Age = 23 },
                new Student() { Name = "Mukdho", Age = 25 }
            };

            List<Student> list2 = new List<Student>
            {
                new Student() { Name = "Zihad", Age = 20 },
                new Student() { Name = "Khalid", Age = 21 },
                new Student() { Name = "Shaon", Age = 26 }
            };


            var allStudents = list1.Concat(list2);

            var query = from student in allStudents
                        orderby student.Name, student.Age
                        select new { student.Name };

            var result = new List<string>();

            foreach (var item in query)
            {
                result.Add(item.Name);
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
