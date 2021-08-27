using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using LibraryManagementSystem.Borrow.BusinessObjects;
using LibraryManagementSystem.Borrow.Services;

namespace LibraryManagementSystem.Web.Areas.Admin.Models
{
    public class CreateBookModel
    {
        public string Title { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }

        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public CreateBookModel()
        {
            _bookService = Startup.AutofacContainer.Resolve<IBookService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public void Create()
        {
            _bookService.CreateBook(_mapper.Map<Book>(this));
        }
    }
}
