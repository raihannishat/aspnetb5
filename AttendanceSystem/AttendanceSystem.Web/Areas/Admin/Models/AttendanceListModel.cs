using System;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSystem.Presence.Services;
using AttendanceSystem.Web.Models;

namespace AttendanceSystem.Web.Areas.Admin.Models
{
    public class AttendanceListModel
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceListModel()
        {
            _attendanceService = Startup.AutofacContainer.Resolve<IAttendanceService>();
        }

        public AttendanceListModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        public object GetAttendance(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _attendanceService.GetAttendances(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                dataTablesModel.GetSortText(new string[] { "StudentId", "Date", "Id" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                    select new string[]
                    {
                        record.StudentId.ToString(),
                        record.Date.ToString(),
                        record.Id.ToString(),
                    }
                ).ToArray()
            };
        }

        public void Delete(int id)
        {
            _attendanceService.DeleteAttendance(id);
        }
    }
}
