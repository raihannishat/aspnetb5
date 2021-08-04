using System;
using AttendanceSystem.Data;

namespace AttendanceSystem.Presence.Entities
{
    public class Attendance : IEntity<int>
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public Student Student { get; set; }
    }
}
