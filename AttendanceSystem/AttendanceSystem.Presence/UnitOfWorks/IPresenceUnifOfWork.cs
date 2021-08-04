using AttendanceSystem.Data;
using AttendanceSystem.Presence.Repositories;

namespace AttendanceSystem.Presence.UnitOfWorks
{
    public interface IPresenceUnifOfWork : IUnitOfWork
    {
        IAttendanceRepository AttendanceRepository { get; }
        IStudentRepository StudentRepository { get; }
    }
}
