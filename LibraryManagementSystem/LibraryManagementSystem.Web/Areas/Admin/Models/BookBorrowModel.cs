using System;
using System.Collections.Generic;
using Autofac;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Borrow.Services;
using LibraryManagementSystem.Borrow.BusinessObjects;

namespace LibraryManagementSystem.Web.Areas.Admin.Models
{
    public class BookBorrowModel
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        private readonly IBookService _bookService;

        public BookBorrowModel()
        {
            _bookService = Startup.AutofacContainer.Resolve<IBookService>();
        }

        public BookBorrowModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public void BorrowBook()
        {
            var book = _bookService.GetAllBooks();

            var selecetedBook = book.Where(x => x.Id == BookId).FirstOrDefault();

            var author = new Author
            {
                Id = AuthorId,
                DateOfBirth = DateTime.Now,
                Name = "Raihan Nishat"
            };

            _bookService.BorrowBook(selecetedBook, author);
        }
    }
}
