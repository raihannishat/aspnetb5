using AttendanceSystem.Data;
using System.Collections.Generic;

namespace AttendanceSystem.Presence.Entities
{
    public class Student : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentRollNumber { get; set; }
        public IList<Attendance> Attendances { get; set; }
    }
}
