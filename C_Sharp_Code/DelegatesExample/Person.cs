using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesExample
{
    public class Person
    {
        public string firstName;
        public string lastName;

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public void ShowFirstName(string message)
        {
            Console.WriteLine($"{message} {firstName}");
        }

        public void ShowLastName(string message)
        {
            Console.WriteLine($"{message} {lastName}");
        }
    }
}
