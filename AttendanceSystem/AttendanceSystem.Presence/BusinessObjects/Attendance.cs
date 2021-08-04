using System;

namespace AttendanceSystem.Presence.BusinessObjects
{
    public class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
    }
}
