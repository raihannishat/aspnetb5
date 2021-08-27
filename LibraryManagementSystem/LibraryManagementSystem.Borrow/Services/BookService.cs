using LibraryManagementSystem.Borrow.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Borrow.UnitOfWorks;
using AutoMapper;

namespace LibraryManagementSystem.Borrow.Services
{
    public class BookService : IBookService
    {
        private readonly IBorrowUnitOfWork _borrowUnitOfWork;
        private readonly IMapper _mapper;

        public BookService(IBorrowUnitOfWork borrowUnitOfWork, IMapper mapper)
        {
            _borrowUnitOfWork = borrowUnitOfWork;
            _mapper = mapper;
        }

        public void CreateBook(Book book)
        {
            _borrowUnitOfWork.BookRepository.Add(
                _mapper.Map<Entities.Book>(book));

            _borrowUnitOfWork.Save();
        }

        public void DeleteBook(int bookId)
        {
            _borrowUnitOfWork.BookRepository.Remove(bookId);
            _borrowUnitOfWork.Save();
        }

        public void BorrowBook(Book book, Author author)
        {
            var bookEntity = _borrowUnitOfWork.BookRepository.GetById(book.Id);

            bookEntity.AllAuthorNames.Add(new Entities.BookAuthor()
            {
                Author = new Entities.Author
                {
                    Name = author.Name,
                    DateOfBirth = author.DateOfBirth
                }
            });
        }

        public IList<Book> GetAllBooks()
        {
            var bookEntities = _borrowUnitOfWork.BookRepository.GetAll();
            var books = new List<Book>();

            foreach (var entity in bookEntities)
            {
                books.Add(_mapper.Map<Book>(entity));
            }

            return books;
        }

        public Book GetBook(int id)
        {
            var book = _borrowUnitOfWork.BookRepository.GetById(id);

            if (book == null) return null;

            return _mapper.Map<Book>(book);
        }

        public (IList<Book> records, int total, int totalDisplay) GetBooks(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var bookData = _borrowUnitOfWork.BookRepository.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Title.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize); ;

            var result = (from book in bookData.data
                          select _mapper.Map<Book>(book)).ToList();

            return (result, bookData.total, bookData.totalDisplay);
        }

        public void UpdateBook(Book book)
        {
            var bookEntity = _borrowUnitOfWork.BookRepository.GetById(book.Id);

            if (bookEntity != null)
            {
                _mapper.Map(book, bookEntity);
                _borrowUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find Book");
            }
        }
    }
}
