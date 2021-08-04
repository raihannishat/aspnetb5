﻿using System;
using Autofac;
using SocialNetwork.Profile.Services;
using System.ComponentModel.DataAnnotations;
using SocialNetwork.Profile.BusinessObjects;

namespace SocialNetwork.Web.Areas.Admin.Models
{
    public class EditMemberModel
    {
        public int? Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Name shoul be less than 50 characters")]
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Address shoul be less than 200 characters")]
        public string Address { get; set; }

        private readonly IMemberService _memberService;

        public EditMemberModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
        }

        public EditMemberModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public void LoadModelData(int id)
        {
            var member = _memberService.GetMember(id);
            Id = member?.Id;
            Name = member?.Name;
            DateOfBirth = member?.DateOfBirth;
            Address = member?.Address;
        }

        public void Update()
        {
            _memberService.UpdateMember(new Member
            {
                Id = Id.HasValue ? Id.Value : 0,
                Name = Name,
                DateOfBirth = DateOfBirth.HasValue ? DateOfBirth.Value : DateTime.MinValue,
                Address = Address
            });
        }
    }
}
