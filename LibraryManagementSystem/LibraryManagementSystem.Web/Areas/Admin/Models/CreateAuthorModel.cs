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
    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public CreateAuthorModel()
        {
            _authorService = Startup.AutofacContainer.Resolve<IAuthorService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public void Create()
        {
            _authorService.CreateAuthor(_mapper.Map<Author>(this));
        }
    }
}
