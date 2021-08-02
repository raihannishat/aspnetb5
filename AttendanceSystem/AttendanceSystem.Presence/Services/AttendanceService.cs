using AttendanceSystem.Presence.BusinessObjects;
using AttendanceSystem.Presence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Presence.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IPresenceUnifOfWork _presenceUnifOfWork;

        public AttendanceService(IPresenceUnifOfWork presenceUnifOfWork)
        {
            _presenceUnifOfWork = presenceUnifOfWork;
        }

        public void CreateAttendance(Attendance attendance)
        {
            _presenceUnifOfWork.AttendanceRepository.Add(
                new Entities.Attendance
                {
                    StudentId = attendance.StudentId,
                    Date = attendance.Date
                }
            );

            _presenceUnifOfWork.Save();
        }

        public void DeleteAttendance(int attendanceId)
        {
            _presenceUnifOfWork.AttendanceRepository.Remove(attendanceId);
            _presenceUnifOfWork.Save();
        }

        public IList<Attendance> GetAllAttendances()
        {
            var attendanceEntities = _presenceUnifOfWork.AttendanceRepository.GetAll();
            var attendances = new List<Attendance>();

            foreach (var entity in attendanceEntities)
            {
                attendances.Add(
                    new Attendance
                    {
                        Id = entity.Id,
                        StudentId = entity.StudentId,
                        Date = entity.Date
                    }
                );
            }

            return attendances;
        }

        public Attendance GetAttendance(int id)
        {
            var attendance = _presenceUnifOfWork.AttendanceRepository.GetById(id);

            if (attendance == null) return null;

            return new Attendance
            {
                Id = attendance.Id,
                StudentId = attendance.StudentId,
                Date = attendance.Date
            };
        }

        public (IList<Attendance> records, int total, int totalDisplay) GetAttendances(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var attendanceData = _presenceUnifOfWork.AttendanceRepository.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.StudentId.ToString().Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var result = (from attendance in attendanceData.data
                          select new Attendance
                          {
                              Id = attendance.Id,
                              StudentId = attendance.StudentId,
                              Date = attendance.Date
                          }).ToList();

            return (result, attendanceData.total, attendanceData.totalDisplay);
        }

        public void UpdateAttendance(Attendance attendance)
        {
            if(attendance == null) throw new InvalidOperationException("Attendance is messing");

            var attendanceEntity = _presenceUnifOfWork.AttendanceRepository.GetById(attendance.Id);

            if (attendanceEntity != null)
            {
                attendanceEntity.StudentId = attendance.StudentId;
                attendanceEntity.Date = attendance.Date;
                _presenceUnifOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find Attendance");
            }
        }
    }
}
