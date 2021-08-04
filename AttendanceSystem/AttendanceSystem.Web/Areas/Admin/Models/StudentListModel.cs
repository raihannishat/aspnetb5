using Autofac;
using System.Linq;
using AttendanceSystem.Web.Models;
using AttendanceSystem.Presence.Services;

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
                dataTablesModel.GetSortText(new string[] { "Id", "Name", "StudentRollNumber" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                    select new string[]
                    {
                        record.Id.ToString(),
                        record.Name,
                        record.StudentRollNumber.ToString(),
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
