using RaihanFrameworkCore;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server = DESKTOP-U5E976U; Database = BitCoinPriceDb; Trusted_Connection = true"; ;

            var orm = new MyORM<Students>(connectionString);

            var students = orm.GetAll();

            foreach (var item in students)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.CGPA);
                Console.WriteLine();
            }
        }
    }
}
