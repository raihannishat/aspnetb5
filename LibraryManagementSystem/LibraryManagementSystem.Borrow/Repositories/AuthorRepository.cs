using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Borrow.Entities;
using LibraryManagementSystem.Borrow.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Borrow.Repositories
{
    public class AuthorRepository : Repository<Author, int>, IAuthorRepository
    {
        public AuthorRepository(IBorrowDbContext context) : base((Context)context)
        {

        }
    }
}
