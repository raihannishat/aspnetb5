using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Explore.Models
{
    public class GuidModel
    {
        public Guid MyGuid { get; set; }

        public GuidModel()
        {
            MyGuid = Guid.NewGuid();
        }
    }
}
