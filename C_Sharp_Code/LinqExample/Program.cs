using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExample
{
    class Program
    {
        //static List<Student> students = new List<Student>
        //{
        //    new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81,60}},
        //    new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
        //    new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
        //    new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
        //    new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
        //    new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
        //    new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
        //    new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
        //    new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
        //    new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
        //    new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
        //    new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
        //};
        
        static void Main(string[] args)
        {
            //string sentence = "the quick brown fox jumps over the lazy dog";
            //string[] words = sentence.Split(' ');

            //var query = from word in words
            //            group word.ToUpper() by word.Length into gr
            //            orderby gr.Key
            //            select new { Length = gr.Key, Words = gr };

            //var query2 = words.GroupBy(w => w.Length, w => w.ToUpper())
            //                  .Select(g => new { Length = g.Key, Words = g })
            //                  .OrderBy(o => o.Length);

            //foreach (var obj in query2)
            //{
            //    Console.WriteLine("Words of length {0}:", obj.Length);
            //    foreach (string word in obj.Words)
            //        Console.WriteLine(word);
            //}

            //var studentQuery6 = from student in students
            //                    let totalScore = student.Scores[0] + student.Scores[1] +
            //                    student.Scores[2] + student.Scores[3]
            //                    select totalScore;

            //double averageScore = studentQuery6.Average();

            //var studentQuery8 = from student in students
            //                    let x = student.Scores[0] + student.Scores[1] +
            //                    student.Scores[2] + student.Scores[3]
            //                    where x > averageScore
            //                    select new { id = student.ID, score = x };

            //foreach (var item in studentQuery8)
            //{
            //    Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score);
            //}

            //IEnumerable<string> studentQuery7 = from student in students
            //                                    where student.Last == "Garcia"
            //                                    select student.First;

            //Console.WriteLine("The Garcias in the class are:");

            //foreach (string s in studentQuery7)
            //{
            //    Console.WriteLine(s);
            //}

            //Console.WriteLine("Class average score = {0}", averageScore);

            //var studentQuery5 = from student in students
            //                    let totalScore = student.Scores[0] + student.Scores[1] +
            //                    student.Scores[2] + student.Scores[3]
            //                    where totalScore / 4 < student.Scores[0]
            //                    select student.Last + " " + student.First;

            //foreach (string s in studentQuery5)
            //{
            //    Console.WriteLine(s);
            //}

            //IEnumerable<Student> studentQuery = from student in students
            //                                    where student.Scores[0] > 90
            //                                    select student;

            // var query_1 = students.Where(x => x.Scores[0] > 90).ToList();

            //var studentQuery2 = from student in students
            //                    group student by student.Last[0];

            //var query_2 = students.GroupBy(x => x.Last[0]).ToList();

            //var studentQuery4 = from student in students
            //                    group student by student.Last[0] into studentGroup
            //                    orderby studentGroup.Key
            //                    select studentGroup;

            //var query_4 = students.GroupBy(x => x.Last[0]).OrderBy(y => y.Key).ToList();

            //foreach (var groupOfStudents in studentQuery4)
            //{
            //    Console.WriteLine(groupOfStudents.Key);
            //    foreach (var student in groupOfStudents)
            //    {
            //        Console.WriteLine(" {0}, {1}",
            //        student.Last, student.First);
            //    }
            //}

            //foreach (var studentGroup in studentQuery2)
            //{
            //    Console.WriteLine(studentGroup.Key);
            //    foreach (Student student in studentGroup)
            //    {
            //        Console.WriteLine(" {0}, {1}", student.Last, student.First);
            //    }
            //}

            //foreach (Student student in studentQuery)
            //{
            //    Console.WriteLine("{0}, {1}", student.Last, student.First);
            //}


            //foreach (var item in newStudentQuery)
            //{
            //    Console.WriteLine($"{item.First} {item.Last}");
            //}


            /*
            IEnumerable<Student> studentsQuery = from student in students
                                                 where student.Scores[3] > 90
                                                 select student;

            foreach (var item in studentsQuery)
            {
                Console.WriteLine($"{item.Last}, {item.First}");
            }
            */

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

            /*
            var studentList = new List<Student>()
            {
                new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81,60}},
                new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
                new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
                new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}}
            };

            var myList = from student in studentList
                         where student.Scores[1] > 90
                         select student;

            var singleStudent = studentList.Where(x => x.Scores[1] > 90).FirstOrDefault();

            Console.WriteLine($"{singleStudent.First} {singleStudent.Last}");

            foreach (var item in myList)
            {
                Console.WriteLine($"{item.First} {item.Last}");
            }
            */
        }
    }
}
