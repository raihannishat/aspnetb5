using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Borrow.Services;
using Autofac;
using LibraryManagementSystem.Web.Models;

namespace LibraryManagementSystem.Web.Areas.Admin.Models
{
    public class AuthorListModel
    {
        private readonly IAuthorService _authorService;

        public AuthorListModel()
        {
            _authorService = Startup.AutofacContainer.Resolve<IAuthorService>();
        }

        public AuthorListModel(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public object GetAuthors(DataTablesAjaxRequestModel dataTablesModel)
        {
            var data = _authorService.GetAuthors(
                dataTablesModel.PageIndex,
                dataTablesModel.PageSize,
                dataTablesModel.SearchText,
                dataTablesModel.GetSortText(new string[] { "Id", "Name", "DateOfBirth" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Id.ToString(),
                            record.Name.ToString(),
                            record.DateOfBirth.ToString(),
                            record.Id.ToString()
                        }
                ).ToArray()
            };
        }

        public void Delete(int id)
        {
            _authorService.DeleteAuthor(id);
        }
    }
}
