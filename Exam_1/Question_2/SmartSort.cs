using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2
{
    public class SmartSort<T> where T : class
    {
        public static IList<T> Sort<T>(this IList<T> elements, Func<T, T, int> compare)
        {
            throw new NotImplementedException();
        }
    }
}
