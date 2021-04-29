using System;
using System.Linq;
using System.Collections.Generic;

namespace SwitchExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            //string domain = Console.ReadLine().Trim().ToLower();

            //string result = domain switch
            //{
            //    "us" => "United States",
            //    "de" => "Germany",
            //    "sk" => "Slovakia",
            //    "hu" => "Hungary",
            //    _ => "Unknown"
            //};

            //Console.WriteLine(result);

            //int age = 23;
            //string name = "Peter";

            //List<string> colors = new List<string> { "blue", "khaki", "orange" };
            //var nums = new int[] { 1, 2, 3, 4, 5 };

            //Console.WriteLine(check(age));
            //Console.WriteLine(check(name));
            //Console.WriteLine(check(colors));
            //Console.WriteLine(check(nums));

            //object check(object val) => val switch
            //{
            //    int => "integer",
            //    string => "string",
            //    List<string> => "list of strings",
            //    Array => "array",
            //    _ => "unknown"
            //};

            //var nums = new List<int> { -3, 2, 0, 1, 9, -2, 7 };

            //foreach (var num in nums)
            //{
            //    var res = num switch
            //    {
            //        < 0 => "negative",
            //        0 => "zero",
            //        >= 0 => "positive"
            //    };

            //    Console.WriteLine($"{num} is {res}");
            //}

            //var users = new List<User>
            //{
            //    new User("Peter Novak", "driver", new DateTime(2000, 12, 1)),
            //    new User("John Doe", "gardener", new DateTime(1996, 2, 10)),
            //    new User("Roger Roe", "teacher", new DateTime(1976, 5, 9)),
            //    new User("Lucia Smith", "student", new DateTime(2007, 8, 18)),
            //    new User("Roman Green", "retired", new DateTime(1945, 7, 21)),
            //};

            //foreach (var user in users)
            //{
            //    int age = GetAge(user);

            //    string res = age switch
            //    {
            //        > 65 => "senior",
            //        >= 18 and <= 64 => "adult",
            //        < 18 => "minor",
            //        _ => "unknown",
            //    };

            //    Console.WriteLine($"{user.Name} is {res}");
            //}

            //int GetAge(User user)
            //{
            //    return (int)Math.Floor((DateTime.Now - user.Dob).TotalDays / 365.25D);
            //}

            //var q = @"
            //WWI started in:

            //1) 1912
            //2) 1914
            //3) 1918
            //";

            //Console.WriteLine(q);

            //var inp = Console.ReadLine();
            //var ans = int.Parse(inp.Trim());

            //var res = ans switch
            //{
            //    1 or 3 => "Incorrect",
            //    2 => "correct",
            //    _ => "unknown option"
            //};

            //Console.WriteLine(res);

            //var products = new List<Product>
            //{
            //    new Product("Product A", 70m, 1, 10),
            //    new Product("Product B", 50m, 3, 15),
            //    new Product("Product C", 35m, 2, 20),
            //};

            //foreach (var product in products)
            //{
            //    Decimal sum = product switch
            //    {
            //        Product { Quantity: 2 } =>
            //                product.Price * product.Quantity * (1 - product.Discount / 100m),
            //        _ => product.Price * product.Quantity,
            //    };

            //    Console.WriteLine($"The final sum for {product.Name} is {sum}");
            //}

            //while (true)
            //{
            //    var menu = "Select: \n1 -> rock\n2 -> paper\n3 -> scissors\n4 -> finish";
            //    Console.WriteLine(menu);

            //    string[] options = { "rock", "paper", "scissors" };

            //    int val;

            //    try
            //    {

            //        var line = Console.ReadLine();
            //        if (string.IsNullOrEmpty(line))
            //        {
            //            Console.WriteLine("Invalid choice");
            //            continue;
            //        }

            //        val = int.Parse(line);
            //    }
            //    catch (FormatException)
            //    {
            //        Console.WriteLine("Invalid choice");
            //        continue;
            //    }

            //    if (val == 4)
            //    {
            //        break;
            //    }

            //    if (val < 1 || val > 4)
            //    {
            //        Console.WriteLine("Invalid choice");
            //        continue;
            //    }

            //    string human = options[val - 1];

            //    var rnd = new Random();
            //    int n = rnd.Next(0, 3);

            //    string computer = options[n];

            //    Console.WriteLine($"I have {computer}, you have {human}");

            //    var res = RockPaperScissors(human, computer);

            //    Console.WriteLine(res);
            //}

            //Console.WriteLine("game finished");

            //string RockPaperScissors(string human, string computer) => (human, computer) switch
            //{
            //    ("rock", "paper") => "Rock is covered by paper. You loose",
            //    ("rock", "scissors") => "Rock breaks scissors. You win.",
            //    ("paper", "rock") => "Paper covers rock. You win.",
            //    ("paper", "scissors") => "Paper is cut by scissors. You loose.",
            //    ("scissors", "rock") => "Scissors are broken by rock. You loose.",
            //    ("scissors", "paper") => "Scissors cut paper. You win.",
            //    (_, _) => "tie"
            //};
        }
    }

    //record User(string Name, string Occupation, DateTime Dob);
    //record Product(string Name, decimal Price, int Quantity, int Discount);
}
