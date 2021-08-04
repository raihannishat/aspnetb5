using AttendanceSystem.Data;
using AttendanceSystem.Presence.Contexts;
using AttendanceSystem.Presence.Entities;

namespace AttendanceSystem.Presence.Repositories
{
    public class AttendanceRepository : Repository<Attendance, int>, IAttendanceRepository
    {
        public AttendanceRepository(IPresenceDbContext context) : base((Context)context)
        {
            
        }
    }
}
