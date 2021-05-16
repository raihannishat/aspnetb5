using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2
{
    public class MyClass
    {
        public void PublicMethod()
        {
            Console.WriteLine("This is public method");
        }

        private void PrivateMethod()
        {
            Console.WriteLine("This is private method");
        }

        protected virtual void ProtectedMethod()
        {
            Console.WriteLine("This is protected method");
        }

        internal void InternalMethod()
        {
            Console.WriteLine("This is internal method");
        }
    }
}
