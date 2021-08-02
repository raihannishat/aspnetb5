using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceSystem.Presence.BusinessObjects;

namespace AttendanceSystem.Presence.Services
{
    public interface IAttendanceService
    {
        IList<Attendance> GetAllAttendances();
        void CreateAttendance(Attendance attendance);
        (IList<Attendance> records, int total, int totalDisplay) GetAttendances(int pageIndex, int pageSize, string searchText, string sortText);
        Attendance GetAttendance(int id);
        void UpdateAttendance(Attendance attendance);
        void DeleteAttendance(int attendanceId);
    }
}
