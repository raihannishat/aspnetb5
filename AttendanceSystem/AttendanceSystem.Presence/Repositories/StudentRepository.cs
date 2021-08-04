using AttendanceSystem.Data;
using AttendanceSystem.Presence.Contexts;
using AttendanceSystem.Presence.Entities;

namespace AttendanceSystem.Presence.Repositories
{
    public class StudentRepository : Repository<Student, int>, IStudentRepository
    {
        public StudentRepository(IPresenceDbContext context) : base((Context)context)
        {

        }
    }
}
