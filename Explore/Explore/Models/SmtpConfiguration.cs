using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Explore.Models
{
    public class SmtpConfiguration
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Pasword { get; set; }
        public string Port { get; set; }
    }
}
