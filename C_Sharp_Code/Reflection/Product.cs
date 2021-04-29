using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Product
    {
        public string Name;
        public int Price;
        public double Weight;

        public Product(int x)
        {

        }

        public bool IsAvailable()
        {
            return true;
        }
    }
}
