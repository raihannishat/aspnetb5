using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Borrow.Contexts;
using LibraryManagementSystem.Borrow.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Borrow.UnitOfWorks
{
    public class BorrowUnitOfWork : UnitOfWork, IBorrowUnitOfWork
    {
        public BorrowUnitOfWork(IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            IBorrowDbContext dbContext)
            : base((Context)dbContext)
        {
            BookRepository = bookRepository;
            AuthorRepository = authorRepository;   
        }

        public IBookRepository BookRepository { get ; private set; }
        public IAuthorRepository AuthorRepository { get; private set; }
    }
}
