using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace CSharpLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            #region C# LINQ query and method syntax
            /*
            var words = new string[] { "falcon", "eagle", "sky", "tree", "water" };

            var res = from word in words
                      where word.Contains('a')
                      select word;

            var res2 = words.Where(x => x.Contains('a'));

            foreach (var item in res2)
            {
                Console.WriteLine(item);
            }
            */
            #endregion

            #region C# LINQ element access
            /*
            var words = new string[] { "falcon", "oak", "sky", "cloud", "tree", "tea", "water" };

            Console.WriteLine(words.ElementAt(2));
            Console.WriteLine(words.First());
            Console.WriteLine(words.Last());

            Console.WriteLine(words.First(word => word.Length == 3));
            Console.WriteLine(words.Last(word => word.Length == 3));

            var vals = new int[] { 1, 2, 3 };

            vals.Prepend(0);
            vals.Append(4);

            Console.WriteLine(string.Join(", ", vals));

            var vals2 = vals.Prepend(0);
            var vals3 = vals2.Append(4);

            Console.WriteLine(string.Join(", ", vals3));
            */
            #endregion

            #region C# LINQ select
            /*
            var vals = new int[] { 2, 4, 6, 8 };

            var powered = vals.Select(e => Math.Pow(e, 2));
            Console.WriteLine(string.Join(", ", powered));

            var words = new string[] { "sky", "earth", "oak", "falcon" };
            var wordLens = words.Select(e => e.Length);
            Console.WriteLine(string.Join(", ", wordLens));
            */
            #endregion

            #region C# LINQ select into anonymous type
            /*
            var users = new User[]
            {
                new User(1, "John", "London", "2001-04-01"),
                new User(2, "Lenny", "New York", "1997-12-11"),
                new User(3, "Andrew", "Boston", "1987-02-22"),
                new User(4, "Peter", "Prague", "1936-03-24"),
                new User(5, "Anna", "Bratislava", "1973-11-18"),
                new User(6, "Albert", "Bratislava", "1940-12-11"),
                new User(7, "Adam", "Trnava", "1983-12-01"),
                new User(8, "Robert", "Bratislava", "1935-05-15"),
                new User(9, "Robert", "Prague", "1998-03-14")
            };

            var res = from user in users
                      where user.City == "Bratislava"
                      select new { user.Name, user.City };

            var res2 = users.Where(x => x.City == "Bratislava")
                            .Select(y => new { y.Name, y.City });

            foreach (var item in res2)
            {
                Console.WriteLine($"{item.Name}\t{item.City}");
            }
            */
            #endregion

            #region C# LINQ SelectMany
            /*
            int[][] vals =
            {
                new[] { 1, 2, 3 },
                new[] { 4 },
                new[] { 5, 6, 6, 2, 7, 8 }
            };

            var res = vals.SelectMany(array => array).OrderBy(x => x);

            Console.WriteLine(string.Join(", ", res));
            
            var vals = new List<List<int>>
            {
                new List<int> { 1, 2, 3, 3 },
                new List<int> { 4 },
                new List<int> { 5, 6, 6, 7, 7 }
            };

            var res = vals.SelectMany(list => list)
                          .Distinct()
                          .OrderByDescending(e => e);

            Console.WriteLine(string.Join(", ", res));
            */
            #endregion

            #region C# LINQ Concat
            /*
            var users1 = new User[]
            {
                new User("John", "Doe", "gardener"),
                new User("Jane", "Doe", "teacher"),
                new User("Roger", "Roe", "driver")
            };

            var users2 = new User[]
            {
                new User("Peter", "Smith", "teacher"),
                new User("Lucia", "Black", "accountant"),
                new User("Michael", "Novak", "programmer")
            };

            var allUsers = users1.Concat(users2);

            foreach (var item in allUsers)
            {
                Console.WriteLine($"{item.FirstName}\t{item.LastName}\t{item.Occupation}");
            }
            */
            #endregion

            #region C# LINQ filter
            /*
            var words = new List<string> { "sky", "rock", "forest", "new", "falcon", "jewelry", "eagle", "blue", "gray" };

            var query = from word in words
                        where word.Length == 4
                        select word;

            var query2 = words.Where(x => x.Length == 4);

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            var query3 = from word in words
                         where word.StartsWith('f') || word.StartsWith('s')
                         select word;

            foreach (var item in query3)
            {
                Console.WriteLine(item);
            }

            var cars = new List<Car>
            {
                new Car("Audi", 52642),
                new Car("Mercedes", 57127),
                new Car("Skoda", 9000),
                new Car("Volvo", 29000),
                new Car("Bentley", 350000),
                new Car("Citroen", 21000),
                new Car("Hummer", 41400),
                new Car("Volkswagen", 21600)
            };

            var res = from car in cars
                      where car.Price > 30000 && car.Price < 100000
                      select new { car.Name, car.Price };

            foreach (var item in res)
            {
                Console.WriteLine($"{item.Name} {item.Price}");
            }
            */
            #endregion

            #region C# LINQ Cartesian product
            /*
            char[] letters = "abcdefghi".ToCharArray();
            char[] digits = "123456789".ToCharArray();

            var coords = from leter in letters
                         from digit in digits
                         select $"{leter}{digit}";

            foreach (var item in coords)
            {
                Console.Write($"{item} ");

                if (item.EndsWith("9"))
                {
                    Console.WriteLine();
                }
            }
            */
            #endregion

            #region C# LINQ Zip
            /*
            string[] students = { "Adam", "John", "Lucia", "Tom" };
            int[] scores = { 68, 56, 90, 86 };

            var result = students.Zip(scores, (e1, e2) => e1 + "'score: " + e2);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            var left = new[] { 1, 2, 3 };
            var right = new[] { 10, 20, 30 };

            var products = left.Zip(right, (m, n) => m * n);

            Console.WriteLine(string.Join(", ", products));

            int[] codes = Enumerable.Range(1, 5).ToArray();
            string[] states =
            {
                "Alabama",
                "Alaska",
                "Arizona",
                "Arkansas",
                "California"
            };

            var CodesWithStates = codes.Zip(states, (code, state) => code + ": " + state);

            foreach (var item in CodesWithStates)
            {
                Console.WriteLine(item);
            }
            */
            #endregion

            #region C# LINQ built-in aggregate calculations
            /*
            var vals = new List<int> { 6, 2, -3, 4, -5, 9, 7, 8 };
            
            var n1 = vals.Count();
            Console.WriteLine($"There are {n1} elements");

            var n2 = vals.Count(e => e % 2 == 0);
            Console.WriteLine($"There are {n2} even elements");

            var sum = vals.Sum();
            Console.WriteLine($"The sum of all values is: {sum}");

            var s2 = vals.Sum(e => e > 0 ? e : 0);
            Console.WriteLine($"The sum of all positive values is: {s2}");

            var avg = vals.Average();
            Console.WriteLine($"The average of values is: {avg}");

            var max = vals.Max();
            Console.WriteLine($"The maximum value is: {max}");

            var min = vals.Min();
            Console.WriteLine($"The minimum value is: {min}");

            var vals = new List<int> { 1, -2, 3, -4, 5, 6, 7, -8 };
            var s = (from x in vals where x > 0 select x).Sum();

            Console.WriteLine($"The sum of positive values is: {s}");

            var words = new List<string> { "falcon", "eagle", "hawk", "owl" };
            int len = (from x in words select x.Length).Sum();

            Console.WriteLine($"There are {len} letters in the list");
            */
            #endregion

            #region C# LINQ custom aggregate calculations
            /*
            var vals = new List<int> { 6, 2, -3, 4, -5, 9, 7, 8 };

            var sum = vals.Aggregate((total, next) => total + next);
            Console.WriteLine($"The sum is {sum}");

            var product = vals.Aggregate((total, next) => total * next);
            Console.WriteLine($"The product is {product}");
            */
            #endregion

            #region C# LINQ orderby
            /*
            var vals = new int[] { 4, 5, 3, 2, 7, 0, 1, 6 };

            var res = from e in vals
                      orderby e ascending
                      select e;

            var res2 = vals.OrderByDescending(x => x);

            Console.WriteLine(string.Join(", ", res2));

            var users = new List<User>()
            {
                new User("John", "Doe", 1230),
                new User("Lucy", "Novak", 670),
                new User("Ben", "Walter", 2050),
                new User("Robin", "Brown", 2300),
                new User("Amy", "Doe", 1250),
                new User("Joe", "Draker", 1190),
                new User("Janet", "Doe", 980),
                new User("Albert", "Novak", 1930)
            };

            Console.WriteLine("sort ascending by last name and salary");

            var sortUser = users.OrderBy(x => x.LastName)
                                .ThenBy(y => y.Salary);

            foreach (var item in sortUser)
            {
                Console.WriteLine($"{item.LastName} {item.Salary}");
            }

            Console.WriteLine("sort descending by last name and salary");

            var sortUser2 = from user in users
                            orderby user.LastName descending, user.Salary descending
                            select user;

            foreach (var item in sortUser2)
            {
                Console.WriteLine($"{item.LastName} {item.Salary}");
            }
            */
            #endregion

            #region C# LINQ Reverse
            /*
            var vals = new int[] { 1, 3, 6, 0, -1, 2, 9, 9, 8 };

            var rev = vals.Reverse();

            Console.WriteLine(string.Join(", ", rev));

            var rev2 = (from val in vals select val).Reverse();

            Console.WriteLine(string.Join(", ", rev2));
            */
            #endregion

            #region C# LINQ group by
            /*
            var cars = new List<Car>
            {
                new Car("Audi", "red", 52642),
                new Car("Mercedes", "blue", 57127),
                new Car("Skoda", "black", 9000),
                new Car("Volvo", "red", 29000),
                new Car("Bentley", "yellow", 350000),
                new Car("Citroen", "white", 21000),
                new Car("Hummer", "black", 41400),
                new Car("Volkswagen", "white", 21600)
            };

            var group = from car in cars
                        group car by car.Color;

            var group2 = cars.GroupBy(x => x.Color);

            foreach (var x in group2)
            {
                Console.WriteLine(x.Key);

                foreach (var y in x)
                {
                    Console.WriteLine($" {y.Name} {y.Price}");
                }
            }

            var revenues = new Revenue[]
            {
                new Revenue(1, "Q1", 2340),
                new Revenue(2, "Q1", 1200),
                new Revenue(3, "Q1", 980),
                new Revenue(4, "Q2", 340),
                new Revenue(5, "Q2", 780),
                new Revenue(6, "Q3", 2010),
                new Revenue(7, "Q3", 3370),
                new Revenue(8, "Q4", 540)
            };

            var res = from revenue in revenues
                      group revenue by revenue.Quarter
                      into g
                      select new { Quarter = g.Key, Total = g.Sum(e => e.Amount) };

            var res2 = from rev in revenues
                       group rev by rev.Quarter
                       into grp
                       where grp.Count() == 2
                       select new { Quarter = grp.Key, Total = grp.Sum(e => e.Amount) };

            foreach (var item in res2)
            {
                Console.WriteLine($"{item.Quarter} {item.Total}");
            }
            */
            #endregion

            #region C# LINQ join
            /*
            var basketA = new string[] { "coin", "book", "fork", "cord", "needle" };
            var basketB = new string[] { "watches", "coin", "pen", "book", "pencil" };

            var res = from item1 in basketA
                      join item2 in basketB
                      on item1 equals item2
                      select item1;

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            */
            #endregion

            #region C# LINQ partitioning
            /*
            var vals = new int[] { 1, 2, 7, 8, 5, 6, 3, 4, 9, 10 };

            var res1 = vals.Skip(3);
            Console.WriteLine(string.Join(", ", res1));

            var res2 = vals.SkipLast(3);
            Console.WriteLine(string.Join(", ", res2));

            var res3 = vals.SkipWhile(e => e < 5);
            Console.WriteLine(string.Join(", ", res3));

            var res4 = vals.Take(3);
            Console.WriteLine(string.Join(", ", res4));

            var res5 = vals.TakeLast(3);
            Console.WriteLine(string.Join(", ", res5));

            var res6 = vals.TakeWhile(e => e < 5);
            Console.WriteLine(string.Join(", ", res6));
            */
            #endregion

            #region C# LINQ convertions
            /*
            var users = new User[]
            {
                new User(1, "John", "London", "2001-04-01"),
                new User(2, "Lenny", "New York", "1997-12-11"),
                new User(3, "Andrew", "Boston", "1987-02-22"),
                new User(4, "Peter", "Prague", "1936-03-24"),
                new User(5, "Anna", "Bratislava", "1973-11-18"),
                new User(6, "Albert", "Bratislava", "1940-12-11"),
                new User(7, "Adam", "Trnava", "1983-12-01"),
                new User(8, "Robert", "Bratislava", "1935-05-15"),
                new User(9, "Robert", "Prague", "1998-03-14")
            };

            string[] cities = (from user in users select user.City).Distinct().ToArray();

            Console.WriteLine(string.Join(", ", cities));

            List<User> inBratislava = (from user in users where user.City == "Bratislava" select user)
                                      .Distinct()
                                      .ToList();

            foreach (var item in inBratislava)
            {
                Console.WriteLine(item.Name);
            }

            Dictionary<int, string> userId = (from user in users select user)
                                             .ToDictionary(user => user.id, user => user.Name);

            foreach (var item in userId)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            */
            #endregion

            #region C# LINQ generating sequences
            /*
            var res = Enumerable.Range(1, 10).Select(e => Math.Pow(e, 3));

            Console.WriteLine(string.Join(", ", res));

            var vals = new int[] { 8, 4, 3, 2, 5, 11, 15, 10, 3, 5, 6 };

            var lines = vals.Select(e => Enumerable.Repeat("*", e)).ToArray();

            foreach (var item in lines)
            {
                Console.WriteLine(string.Join("", item));
            }

            var nums = new int[] { 1, 3, 2, 3, 3, 3, 4, 4, 10, 10 };

            var powered = nums.Aggregate(Enumerable.Empty<double>(), (totat, next) => totat
                              .Append(Math.Pow(next, 2)));

            foreach (var item in powered)
            {
                Console.WriteLine(item);
            }
            */
            #endregion

            #region C# LINQ quantifiers
            /*
            var vals = new List<int> { -1, -3, 0, 1, -3, 2, 9, -4 };

            bool positive = vals.Any(x => x > 0);

            if (positive)
            {
                Console.WriteLine("There is a positive value");
            }

            bool allPositive = vals.All(x => x > 0);

            if (allPositive)
            {
                Console.WriteLine("All values are positive");
            }

            bool hasSix = vals.Contains(6);

            if (hasSix)
            {
                Console.WriteLine("6 value is in the array");
            }
            */
            #endregion

            #region C# LINQ set operations
            /*
            var vals1 = "abcde".ToCharArray();
            var vals2 = "defgh".ToCharArray();

            var data = vals1.Union(vals2);
            Console.WriteLine("{" + string.Join(" ", data) + "}");

            var data2 = vals1.Intersect(vals2);
            Console.WriteLine("{" + string.Join(" ", data2) + "}");

            var data3 = vals1.Except(vals2);
            Console.WriteLine("{" + string.Join(" ", data3) + "}");

            var nums = new int[] { 1, 1, 2, 3, 4, 4, 4, 5, 6, 7, 7, 8 };

            var data4 = nums.Distinct();

            Console.WriteLine("{" + string.Join(", ", data4) + "}");
            */
            #endregion

            #region C# LINQ XML
            /*
            string myXML = @"
            <Users>
                <User>
                    <Name>Jack</Name>
                    <Sex>male</Sex>
                </User>
                <User>
                    <Name>Paul</Name>
                    <Sex>male</Sex>
                </User>
                <User>
                    <Name>Frank</Name>
                    <Sex>male</Sex>
                </User>
                <User>
                    <Name>Martina</Name>
                    <Sex>female</Sex>
                </User>
                <User>
                    <Name>Lucia</Name>
                    <Sex>female</Sex>
                </User>
            </Users>";

            var xdoc = new XDocument();

            xdoc = XDocument.Parse(myXML);

            var females = from u in xdoc.Root.Descendants()
                          where (string)u.Element("Sex") == "female"
                          select u.Element("Name");

            foreach (var e in females)
            {
                Console.WriteLine("{0}", e);
            }
            */
            #endregion

            #region C# LINQ list directory contents
            /*
            var path = @"D:\Software";

            var files = from file in Directory.EnumerateFiles(path, "*.exe", SearchOption.AllDirectories)
                        select file;

            var files2 = from file in Directory.EnumerateFiles(path, "*.exe", SearchOption.AllDirectories)
                         where Path
                         .GetFileName(file)
                         .ToLower()
                         .Contains("data")
                         select file;

            foreach (var file in files)
            {
                Console.WriteLine("{0}", file);
            }

            Console.WriteLine("{0} files found.", files.Count().ToString());
            */
            #endregion

            #region C# LINQ let clause
            /*
            var path = @"D:\Code\GitHub\aspnetb5\C_Sharp_Code\CSharpLinq\bin\Debug\net5.0\data.csv";

            var lines = File.ReadLines(path, Encoding.UTF8);

            var users = from line in lines
                        let fields = line.Replace(", ", ",").Split(",")
                        select new User(fields[0], fields[1], DateTime.Parse(fields[2]));

            var sorted = from user in users
                         orderby user.DateOfBirth descending
                         select user;

            foreach (var user in sorted)
            {
                Console.WriteLine(user);
            }
            */
            #endregion
        }
    }
}
