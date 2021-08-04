using System;
using Autofac;
using SocialNetwork.Profile.Services;
using SocialNetwork.Profile.BusinessObjects;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Web.Areas.Admin.Models
{
    public class CreateMemberModel
    {
        private readonly IMemberService _memberService;

        public CreateMemberModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
        }

        public CreateMemberModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [Required, MaxLength(50, ErrorMessage = "Name shoul be less than 50 characters")]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Address shoul be less than 200 characters")]
        public string Address { get; set; }

        public void Create()
        {
            _memberService.CreateMember(new Member
            {
                Name = Name,
                DateOfBirth = DateOfBirth,
                Address = Address
            });
        }
    }
}
