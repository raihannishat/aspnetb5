using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Borrow.Services;
using Autofac;
using LibraryManagementSystem.Web.Models;

namespace LibraryManagementSystem.Web.Areas.Admin.Models
{
    public class BookListModel
    {
        private readonly IBookService _bookService;

        public BookListModel()
        {
            _bookService = Startup.AutofacContainer.Resolve<IBookService>();
        }

        public BookListModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public object GetBooks(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _bookService.GetBooks(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                dataTablesModel.GetSortText(new string[] { "Id", "Title", "Barcode", "Price" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Id.ToString(),
                            record.Title.ToString(),
                            record.Barcode.ToString(),
                            record.Price.ToString(),
                            record.Id.ToString()
                        }
                ).ToArray()
            };
        }

        public void Delete(int id)
        {
            _bookService.DeleteBook(id);
        }
    }
}
