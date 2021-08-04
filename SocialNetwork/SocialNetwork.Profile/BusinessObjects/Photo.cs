using System;

namespace SocialNetwork.Profile.BusinessObjects
{
    public class Photo
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string PhotoFileName { get; set; }
    }
}
