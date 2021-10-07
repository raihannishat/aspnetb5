using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DataImporter.Core;
using DataImporter.Library.Services;

namespace DataImporter.Web.Models.Groups
{
    public class GroupListModel
    {
        private readonly IGroupService _groupService;

        public GroupListModel()
        {
            _groupService = Startup.AutofacContainer.Resolve<IGroupService>();
        }

        public GroupListModel(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public object GetGroups(DataTablesAjaxRequestModel tableModel)
        {
            var data = _groupService.GetGroups(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Id", "Name" }));

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
