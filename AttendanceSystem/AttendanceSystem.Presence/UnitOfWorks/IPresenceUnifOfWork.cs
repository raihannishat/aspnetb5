using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
