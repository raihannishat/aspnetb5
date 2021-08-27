using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Borrow.Repositories;

namespace LibraryManagementSystem.Borrow.UnitOfWorks
{
    public interface IBorrowUnitOfWork : IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IAuthorRepository AuthorRepository { get; }
    }
}
