using Autofac;
using AttendanceSystem.Presence.Services;
using AttendanceSystem.Presence.BusinessObjects;

namespace AttendanceSystem.Web.Areas.Admin.Models
{
    public class EditStudentModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? StudentRollNumber { get; set; }

        private readonly IStudentService _studentService;

        public EditStudentModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }

        public EditStudentModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void LoadModelData(int id)
        {
            var student = _studentService.GetStudent(id);
            Id = student?.Id;
            Name = student?.Name;
            StudentRollNumber = student?.StudentRollNumber;
        }

        public void Update()
        {
            _studentService.UpdateStudent(
                new Student
                {
                    Id = Id.HasValue ? Id.Value : 0,
                    Name = Name,
                    StudentRollNumber = StudentRollNumber.HasValue ? StudentRollNumber.Value : 0
                }
            );
        }
    }
}
