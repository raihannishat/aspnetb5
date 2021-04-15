using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLinq
{
    public partial class Car
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Car(string Name, int Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
    }

    public partial class Car
    {
        public string Color { get; set; }

        public Car(string Name, string Color, int Price)
        {
            this.Name = Name;
            this.Color = Color;
            this.Price = Price;
        }
    }
}
