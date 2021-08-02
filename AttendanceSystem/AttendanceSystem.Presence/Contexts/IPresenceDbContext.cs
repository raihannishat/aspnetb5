using AttendanceSystem.Presence.Entities;
using Microsoft.EntityFrameworkCore;

namespace AttendanceSystem.Presence.Contexts
{
    public interface IPresenceDbContext
    {
        DbSet<Attendance> Attendances { get; }
        DbSet<Student> Students { get; }
    }
}