using LibraryManagementSystem.Borrow.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagementSystem.Borrow.UnitOfWorks;

namespace LibraryManagementSystem.Borrow.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IBorrowUnitOfWork _borrowUnitOfWork;
        private readonly IMapper _mapper;

        public AuthorService(IBorrowUnitOfWork borrowUnitOfWork, IMapper mapper)
        {
            _borrowUnitOfWork = borrowUnitOfWork; 
            _mapper = mapper;
        }

        public void CreateAuthor(Author author)
        {
            _borrowUnitOfWork.AuthorRepository.Add(
                _mapper.Map<Entities.Author>(author));

            _borrowUnitOfWork.Save();
        }

        public void DeleteAuthor(int authorId)
        {
            _borrowUnitOfWork.AuthorRepository.Remove(authorId);
            _borrowUnitOfWork.Save();
        }

        public Author GetAuthor(int id)
        {
            var author = _borrowUnitOfWork.AuthorRepository.GetById(id);

            if (author == null) return null;

            return _mapper.Map<Author>(author);
        }

        public IList<Author> GetAuthors()
        {
            var authorEntities = _borrowUnitOfWork.AuthorRepository.GetAll();
            var authors = new List<Author>();

            foreach (var entity in authorEntities)
            {
                authors.Add(_mapper.Map<Author>(entity));
            }

            return authors;
        }

        public (IList<Author> records, int total, int totalDisplay) GetAuthors(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var authorData = _borrowUnitOfWork.AuthorRepository.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize); ;

            var result = (from author in authorData.data
                          select _mapper.Map<Author>(author)).ToList();

            return (result, authorData.total, authorData.totalDisplay);
        }

        public void UpdateAuthor(Author author)
        {
            var authorEntity = _borrowUnitOfWork.AuthorRepository.GetById(author.Id);

            if (authorEntity != null)
            {
                _mapper.Map(author, authorEntity);
                _borrowUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find Author");
            }
        }
    }
}
