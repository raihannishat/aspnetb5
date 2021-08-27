using LibraryManagementSystem.Borrow.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Borrow.Contexts
{
    public interface IBorrowDbContext
    {
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
    }
}