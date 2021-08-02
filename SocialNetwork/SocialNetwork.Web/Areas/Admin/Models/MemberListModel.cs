using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using SocialNetwork.Profile.Services;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.Areas.Admin.Models
{
    public class MemberListModel
    {
        private readonly IMemberService _memberService;

        public MemberListModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
        }

        public MemberListModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public object GetMembers(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _memberService.GetMembers(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                dataTablesModel.GetSortText(new string[] { "Name", "DateOfBirth", "Address", "Id" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.DateOfBirth.ToString(),
                            record.Address.ToString(),
                            record.Id.ToString(),
                            record.Id.ToString(),
                        }
                ).ToArray()
            };
        }

        public void Delete(int id)
        {
            _memberService.DeleteMember(id);
        }
    }
}
