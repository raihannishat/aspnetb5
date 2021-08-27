using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagementSystem.Borrow.BusinessObjects;
using LibraryManagementSystem.Web.Areas.Admin.Models;

namespace LibraryManagementSystem.Web
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<AuthorListModel, Author>().ReverseMap();
            CreateMap<CreateAuthorModel, Author>().ReverseMap();
            CreateMap<EditAuthorModel, Author>().ReverseMap();
            CreateMap<BookListModel, Book>().ReverseMap();
            CreateMap<CreateBookModel, Book>().ReverseMap();
            CreateMap<EditBookModel, Book>().ReverseMap();
        }
    }
}
