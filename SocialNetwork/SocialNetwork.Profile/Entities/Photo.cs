using SocialNetwork.Data;

namespace SocialNetwork.Profile.Entities
{
    public class Photo : IEntity<int>
    {
        public int Id { get; set ; }
        public int MemberId { get; set; }
        public string PhotoFileName { get; set; }
        public Member Member { get; set; }
    }
}
