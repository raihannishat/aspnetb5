using Autofac;
using System.Linq;
using AttendanceSystem.Web.Models;
using AttendanceSystem.Presence.Services;

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
                dataTablesModel.GetSortText(new string[] { "Id", "StudentId", "Date" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                    select new string[]
                    {
                        record.Id.ToString(),
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
