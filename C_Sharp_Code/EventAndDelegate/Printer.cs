using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndDelegate
{
    public class Printer
    {
        public void PrintFormate1(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine($"--::{text}::--");
            }
        }

        public void PrintFormate2(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                Console.WriteLine($"##--{text}--##");
            }
        }
    }
}
