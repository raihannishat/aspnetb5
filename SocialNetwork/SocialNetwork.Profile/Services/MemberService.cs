using System;
using System.Linq;
using System.Collections.Generic;
using SocialNetwork.Profile.UnitOfWorks;
using SocialNetwork.Profile.BusinessObjects;

namespace SocialNetwork.Profile.Services
{
    public class MemberService : IMemberService
    {
        private readonly IProfileUnitOfWork _profileUnitOfWork;

        public MemberService(IProfileUnitOfWork profileUnitOfWork)
        {
            _profileUnitOfWork = profileUnitOfWork;
        }

        public void CreateMember(Member member)
        {
            _profileUnitOfWork.MemberRepository.Add(
                new Entities.Member
                {
                    Name = member.Name,
                    DateOfBirth = member.DateOfBirth,
                    Address = member.Address
                }
            );

            _profileUnitOfWork.Save();
        }

        public void DeleteMember(int memberId)
        {
            _profileUnitOfWork.MemberRepository.Remove(memberId);
            _profileUnitOfWork.Save();
        }

        public IList<Member> GetAllMembers()
        {
            var memberEntity = _profileUnitOfWork.MemberRepository.GetAll();
            var members = new List<Member>();

            foreach (var entity in memberEntity)
            {
                members.Add(new Member
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    DateOfBirth = entity.DateOfBirth,
                    Address = entity.Address
                });
            }

            return members;
        }

        public Member GetMember(int id)
        {
            var member = _profileUnitOfWork.MemberRepository.GetById(id);

            if (member == null) return null;

            return new Member
            {
                Id = member.Id,
                Name = member.Name,
                DateOfBirth = member.DateOfBirth,
                Address = member.Address
            };
        }

        public (IList<Member> records, int total, int totalDisplay) GetMembers(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var memberData = _profileUnitOfWork.MemberRepository.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize); ;

            var result = (from member in memberData.data
                          select new Member
                          {
                              Id = member.Id,
                              Name = member.Name,
                              DateOfBirth = member.DateOfBirth,
                              Address = member.Address
                          }).ToList();

            return (result, memberData.total, memberData.totalDisplay);
        }

        public void UpdateMember(Member member)
        {
            if (member == null) throw new InvalidOperationException("Member is messing");

            var memberEntity = _profileUnitOfWork.MemberRepository.GetById(member.Id);

            if (memberEntity != null)
            {
                memberEntity.Name = member.Name;
                memberEntity.DateOfBirth = member.DateOfBirth;
                memberEntity.Address = member.Address;
                _profileUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find member");
            }
        }
    }
}
