using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Borrow.BusinessObjects;

namespace LibraryManagementSystem.Borrow.Services
{
    public interface IBookService
    {
        IList<Book> GetAllBooks();
        void CreateBook(Book book);
        (IList<Book> records, int total, int totalDisplay) GetBooks(int pageIndex, int pageSize, string searchText, string sortText);
        Book GetBook(int id);
        void UpdateBook(Book book);
        void DeleteBook(int bookId);
        void BorrowBook(Book book, Author author);
    }
}
