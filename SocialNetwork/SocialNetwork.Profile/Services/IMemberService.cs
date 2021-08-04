using System.Collections.Generic;
using SocialNetwork.Profile.BusinessObjects;

namespace SocialNetwork.Profile.Services
{
    public interface IMemberService
    {
        IList<Member> GetAllMembers();
        void CreateMember(Member member);
        (IList<Member> records, int total, int totalDisplay) GetMembers(int pageIndex, int pageSize, string searchText, string sortText);
        Member GetMember(int id);
        void UpdateMember(Member member);
        void DeleteMember(int memberId);
    }
}
