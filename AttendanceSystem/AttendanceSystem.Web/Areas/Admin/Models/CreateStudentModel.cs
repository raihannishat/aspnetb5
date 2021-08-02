﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSystem.Presence.BusinessObjects;
using AttendanceSystem.Presence.Services;

namespace AttendanceSystem.Web.Areas.Admin.Models
{
    public class CreateStudentModel
    {
        public string Name { get; set; }
        public int StudentRollNumber { get; set; }

        private readonly IStudentService _studentService;

        public CreateStudentModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }

        public CreateStudentModel(IStudentService studentService)
        {
            _studentService = studentService;   
        }

        public void Create()
        {
            _studentService.CreateStudent(
                new Student
                {
                    Name = Name,
                    StudentRollNumber = StudentRollNumber
                }
            );
        }
    }
}
