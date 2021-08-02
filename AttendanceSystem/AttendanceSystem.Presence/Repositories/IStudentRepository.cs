using AttendanceSystem.Data;
using AttendanceSystem.Presence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Presence.Repositories
{
    public interface IStudentRepository : IRepository<Student, int>
    {

    }
}
