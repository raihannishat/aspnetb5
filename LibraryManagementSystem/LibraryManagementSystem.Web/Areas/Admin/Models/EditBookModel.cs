using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Borrow.BusinessObjects;
using LibraryManagementSystem.Borrow.Services;
using AutoMapper;
using Autofac;

namespace LibraryManagementSystem.Web.Areas.Admin.Models
{
    public class EditBookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }

        public readonly IBookService _bookService;
        public readonly IMapper _mapper;

        public EditBookModel()
        {
            _bookService = Startup.AutofacContainer.Resolve<IBookService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public EditBookModel(IBookService bookService)
        {
            _bookService = bookService;
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public void LoadModelData(int id)
        {
            _mapper.Map(_bookService.GetBook(id), this);
        }

        public void Update()
        {
            _bookService.UpdateBook(_mapper.Map(this, new Book()));
        }
    }
}
