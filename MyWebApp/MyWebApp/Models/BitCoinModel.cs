using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Models
{
    public class BitCoinModel
    {
        public Guid Guid { get; set; }

        public BitCoinModel()
        {
            Guid = Guid.NewGuid();
        }
    }
}
