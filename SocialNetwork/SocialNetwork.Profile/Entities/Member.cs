using System;
using SocialNetwork.Data;
using System.Collections.Generic;

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
