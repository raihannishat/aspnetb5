using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceSystem.Data;
using AttendanceSystem.Presence.Contexts;
using AttendanceSystem.Presence.Entities;
using Microsoft.EntityFrameworkCore;

namespace AttendanceSystem.Presence.Repositories
{
    public class StudentRepository : Repository<Student, int>, IStudentRepository
    {
        public StudentRepository(IPresenceDbContext context) : base((Context)context)
        {

        }
    }
}
