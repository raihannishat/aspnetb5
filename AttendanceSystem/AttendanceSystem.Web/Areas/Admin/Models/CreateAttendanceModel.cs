﻿using System;
using Autofac;
using AttendanceSystem.Presence.Services;
using AttendanceSystem.Presence.BusinessObjects;

namespace AttendanceSystem.Web.Areas.Admin.Models
{
    public class CreateAttendanceModel
    {
        public int StudentId { get; set; }
        public DateTime Date { get; set; }

        private readonly IAttendanceService _attendanceService;

        public CreateAttendanceModel()
        {
            _attendanceService = Startup.AutofacContainer.Resolve<IAttendanceService>();
        }

        public CreateAttendanceModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService; 
        }

        public void Create()
        {
            _attendanceService.CreateAttendance(
                new Attendance
                {
                    StudentId = StudentId,
                    Date = Date
                }
            );
        }
    }
}
