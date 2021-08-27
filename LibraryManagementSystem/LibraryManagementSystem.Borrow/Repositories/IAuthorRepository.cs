using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Borrow.Entities;

namespace LibraryManagementSystem.Borrow.Repositories
{
    public interface IAuthorRepository : IRepository<Author, int>
    {

    }
}
