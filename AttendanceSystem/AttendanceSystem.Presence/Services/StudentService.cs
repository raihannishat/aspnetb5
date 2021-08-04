using System;
using System.Linq;
using System.Collections.Generic;
using AttendanceSystem.Presence.UnitOfWorks;
using AttendanceSystem.Presence.BusinessObjects;

namespace AttendanceSystem.Presence.Services
{
    public class StudentService : IStudentService
    {
        private readonly IPresenceUnifOfWork _presenceUnifOfWork;

        public StudentService(IPresenceUnifOfWork presenceUnifOfWork)
        {
            _presenceUnifOfWork = presenceUnifOfWork;
        }

        public void CreateStudent(Student student)
        {
            _presenceUnifOfWork.StudentRepository.Add(
                new Entities.Student
                {
                    Name = student.Name,
                    StudentRollNumber = student.StudentRollNumber
                }
            );

            _presenceUnifOfWork.Save();
        }

        public void DeleteStudent(int studentId)
        {
            _presenceUnifOfWork.StudentRepository.Remove(studentId);
            _presenceUnifOfWork.Save();
        }

        public List<Student> GetAllStudents()
        {
            var studentEntities = _presenceUnifOfWork.StudentRepository.GetAll();
            var students = new List<Student>();

            foreach (var entity in studentEntities)
            {
                students.Add(
                    new Student
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        StudentRollNumber = entity.StudentRollNumber
                    }    
                );
            }

            return students;
        }

        public Student GetStudent(int id)
        {
            var student = _presenceUnifOfWork.StudentRepository.GetById(id);

            if (student == null) return null;

            return new Student
            {
                Id = student.Id,
                Name = student.Name,
                StudentRollNumber = student.StudentRollNumber
            };
        }

        public (IList<Student> records, int total, int totalDisplay) GetStudents(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var studentData = _presenceUnifOfWork.StudentRepository.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var result = (from student in studentData.data
                          select new Student
                          {
                              Id = student.Id,
                              Name = student.Name,
                              StudentRollNumber = student.StudentRollNumber
                          }).ToList();

            return (result, studentData.total, studentData.totalDisplay);
        }

        public void UpdateStudent(Student student)
        {
            if (student == null) throw new InvalidOperationException("Student is messing");

            var studentEntity = _presenceUnifOfWork.StudentRepository.GetById(student.Id);

            if(studentEntity != null)
            {
                studentEntity.Name = student.Name;
                studentEntity.StudentRollNumber = student.StudentRollNumber;
                _presenceUnifOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find Student");
            }
        }
    }
}
