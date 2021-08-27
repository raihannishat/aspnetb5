using AutoMapper;
using Entity = LibraryManagementSystem.Borrow.Entities;
using BusinessObject = LibraryManagementSystem.Borrow.BusinessObjects;

namespace LibraryManagementSystem.Borrow
{
    public class BorrowProfile : Profile
    {
        public BorrowProfile()
        {
            CreateMap<Entity.Book, BusinessObject.Book>().ReverseMap();
            CreateMap<Entity.Author, BusinessObject.Author>().ReverseMap();
        }
    }
}
