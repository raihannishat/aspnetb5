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
    public class EditAuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public readonly IAuthorService _authorService;
        public readonly IMapper _mapper;

        public EditAuthorModel()
        {
            _authorService = Startup.AutofacContainer.Resolve<IAuthorService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public EditAuthorModel(IAuthorService authorService)
        {
            _authorService = authorService;
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public void LoadModelData(int id)
        {
            _mapper.Map(_authorService.GetAuthor(id), this);
        }

        public void Update()
        {
            _authorService.UpdateAuthor(_mapper.Map(this, new Author()));
        }
    }
}
