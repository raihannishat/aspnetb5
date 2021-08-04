using Autofac;
using System.Linq;
using SocialNetwork.Web.Models;
using SocialNetwork.Profile.Services;

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
                dataTablesModel.GetSortText(new string[] { "Id", "Name", "DateOfBirth", "Address" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Id.ToString(),
                            record.Name,
                            record.DateOfBirth.ToString(),
                            record.Address.ToString(),
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
