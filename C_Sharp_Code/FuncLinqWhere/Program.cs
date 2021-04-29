using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncLinqWhere
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> HasThree = str => str.Length == 3;

            string[] words =
            {
                "sky", "forest", "wood", "cloud", "falcon", "owl" , "ocean",
                "water", "bow", "tiny", "arc"
            };

            IEnumerable<string> threeLetterWords = words.Where(HasThree);

            Predicate<string> predicate = Cheack;

            var myList = words.ToList().FindAll(predicate);

            Console.WriteLine("Using Predicate : ");
            foreach (var word in myList)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("Using Fucn : ");
            foreach (var word in threeLetterWords)
            {
                Console.WriteLine(word);
            }
        }

        static bool Cheack(string word)
        {
            if (word.Length == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
