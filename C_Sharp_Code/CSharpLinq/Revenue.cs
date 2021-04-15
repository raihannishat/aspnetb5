using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLinq
{
    public class Revenue
    {
        public int Id { get; set; }
        public string Quarter { get; set; }
        public int Amount { get; set; }

        public Revenue(int Id, string Quarter, int Amount)
        {
            this.Id = Id;
            this.Quarter = Quarter;
            this.Amount = Amount;
        }
    }
}
