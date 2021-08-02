using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceSystem.Data;
using AttendanceSystem.Presence.Repositories;
using AttendanceSystem.Presence.Contexts;

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
