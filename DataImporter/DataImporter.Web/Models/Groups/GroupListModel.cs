using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using DataImporter.Core;
using DataImporter.Library.Services;
using Microsoft.AspNetCore.Http;

namespace DataImporter.Web.Models.Groups
{
    public class GroupListModel
    {
        private readonly IGroupService _groupService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GroupListModel()
        {
            _groupService = Startup.AutofacContainer.Resolve<IGroupService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }

        public GroupListModel(IGroupService groupService, IHttpContextAccessor httpContextAccessor)
        {
            _groupService = groupService;
            _httpContextAccessor = httpContextAccessor;
        }

        public object GetGroups(DataTablesAjaxRequestModel tableModel)
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext.User
                        .FindFirst(ClaimTypes.NameIdentifier).Value);

            var data = _groupService.GetGroups(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Id", "Name" }), userId);

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                    select new string[]
                    {
                        record.Id.ToString(),
                        record.Name,
                        record.Id.ToString()
                    }
                ).ToArray()
            };
        }

        public void Delete(int id)
        {
            _groupService.DeleteGroup(id);
        }
    }
}
