﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesExample
{
    public class Operator
    {
        public void Add(int x, int y)
        {
            Console.WriteLine($"{x} + {y} = {x + y}");
        }

        public void Sub(int x, int y)
        {
            Console.WriteLine($"{x} - {y} = {x - y}");
        }
    }
}
