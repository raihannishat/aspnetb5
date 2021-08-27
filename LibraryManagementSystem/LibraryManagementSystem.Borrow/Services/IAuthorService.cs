using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Borrow.BusinessObjects;

namespace LibraryManagementSystem.Borrow.Services
{
    public interface IAuthorService
    {
        IList<Author> GetAuthors();
        void CreateAuthor(Author author);
        (IList<Author> records, int total, int totalDisplay) GetAuthors(int pageIndex, int pageSize, string searchText, string sortText);
        Author GetAuthor(int id);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int authorId);
    }
}
