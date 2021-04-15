using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLinq
{
    public partial class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string DateOfBirth { get; set; }

        public User(int id, string Name, string City, string DateOfBirth)
        {
            this.id = id;
            this.Name = Name;
            this.City = City;
            this.DateOfBirth = DateOfBirth;
        }
    }

    public partial class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Occupation { get; set; }

        public User(string FirstName, string LastName, string Occupation)
        {
            this.FirstName = FirstName; 
            this.LastName = LastName; 
            this.Occupation = Occupation; 
        }
    }

    public partial class User
    {
        public double Salary { get; set; }

        public User(string FirstName, string LastName, double Salary)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Salary = Salary;
        }
    }

    public partial class User
    {
        public DateTime dateOfBirth { get; set; }

        public User(string Name, string Occupation, DateTime dateOfBirth)
        {
            this.Name = Name;
            this.Occupation = Occupation;
            this.dateOfBirth = dateOfBirth;
        }
    }
}
