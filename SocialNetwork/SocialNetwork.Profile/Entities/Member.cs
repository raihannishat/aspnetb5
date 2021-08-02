using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Data;

namespace SocialNetwork.Profile.Entities
{
    public class Member : IEntity<int>
    {
        public int Id { get; set ; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public IList<Photo> Photos { get; set; }
    }
}
