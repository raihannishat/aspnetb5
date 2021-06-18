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

            orm.Update(new Students()
            {
                Id = 1,
                CGPA = 3.50
            });
        }
    }
}
