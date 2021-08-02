using System;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSystem.Presence.BusinessObjects;
using AttendanceSystem.Presence.Services;

namespace AttendanceSystem.Web.Areas.Admin.Models
{
    public class EditAttendanceModel
    {
        public int? Id { get; set; }
        public int? StudentId { get; set; }
        public DateTime? Date { get; set; }

        private readonly IAttendanceService _attendanceService;

        public EditAttendanceModel()
        {
            _attendanceService = Startup.AutofacContainer.Resolve<IAttendanceService>();
        }

        public void LoadModelData(int id)
        {
            var attendance = _attendanceService.GetAttendance(id);
            Id = attendance?.Id;
            StudentId = attendance?.StudentId;
            Date = attendance?.Date;
        }

        public void Update()
        {
            _attendanceService.UpdateAttendance(
                new Attendance
                {
                    Id = Id.HasValue ? Id.Value : 0,
                    StudentId = StudentId.HasValue ? StudentId.Value : 0,
                    Date = Date.HasValue ? Date.Value : DateTime.MinValue
                }
            );
        }
    }
}
