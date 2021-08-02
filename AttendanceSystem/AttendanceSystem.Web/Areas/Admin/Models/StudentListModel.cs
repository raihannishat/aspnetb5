using System;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceSystem.Presence.Services;
using AttendanceSystem.Web.Models;

namespace AttendanceSystem.Web.Areas.Admin.Models
{
    public class StudentListModel
    {
        private readonly IStudentService _studentService;

        public StudentListModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }

        public StudentListModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public object GetStudents(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _studentService.GetStudents(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                dataTablesModel.GetSortText(new string[] { "Name", "StudentRollNumber", "Id" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                    select new string[]
                    {
                        record.Name,
                        record.StudentRollNumber.ToString(),
                        record.Id.ToString(),
                        record.Id.ToString()
                    }
                ).ToArray()
            };  
        }

        public void Delete(int id)
        {
            _studentService.DeleteStudent(id);
        }
    }
}
