using AttendanceSystem.Data;
using AttendanceSystem.Presence.Contexts;
using AttendanceSystem.Presence.Repositories;

namespace AttendanceSystem.Presence.UnitOfWorks
{
    public class PresenceUnitOfWork : UnitOfWork, IPresenceUnifOfWork
    {
        public PresenceUnitOfWork(IPresenceDbContext dbContext, 
            IAttendanceRepository attendanceRepository, 
            IStudentRepository studentRepository) : base((Context)dbContext)
        {
            AttendanceRepository = attendanceRepository;
            StudentRepository = studentRepository;
        }

        public IAttendanceRepository AttendanceRepository { get; private set; }
        public IStudentRepository StudentRepository { get; private set; }
    }
}
