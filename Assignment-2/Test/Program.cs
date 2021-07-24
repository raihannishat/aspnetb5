using RaihanFrameworkCore;
using System;
using ConsoleTables;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server = DESKTOP-U5E976U;" +
                                   "Database = BitCoinPriceDb;" +
                                   "Trusted_Connection = true";

            var student = new Students
            {
                Id = 1,
                Name = "Jalal Uddin",
            };

            var orm = new MyORM<Students>(connectionString);

            #region Create
            //orm.Insert(student);
            #endregion

            #region Read
            //var studentList = orm.GetAll();

            //var table = new ConsoleTable("ID", "Name", "CGPA");

            //foreach (var item in studentList)
            //{
            //    table.AddRow(item.Id, item.Name, item.CGPA);
            //}

            //table.Write();
            #endregion

            #region Update
            //orm.Update(student);
            #endregion

            #region Delete by Entity
            //orm.Delete(student);
            #endregion

            #region Delete by Id
            //orm.Delete(3);
            #endregion

            #region GetById
            //var entity = orm.GetById(3);
            //Console.WriteLine(entity);
            #endregion
        }
    }
}
