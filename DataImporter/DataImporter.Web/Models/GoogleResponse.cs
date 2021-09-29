using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Web.Models
{
    public class GoogleResponse
    {
        public bool Success { get; set; }
        public double Score { get; set; }
        public string Action { get; set; }
        public DateTime ChallengeTest { get; set; }
        public string HostName { get; set; }
    }
}
