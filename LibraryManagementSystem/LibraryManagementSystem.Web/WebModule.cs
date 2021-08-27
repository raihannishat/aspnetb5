using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using LibraryManagementSystem.Web.Areas.Admin.Models;

namespace LibraryManagementSystem.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthorListModel>().AsSelf();
            builder.RegisterType<BookListModel>().AsSelf();
            builder.RegisterType<EditAuthorModel>().AsSelf();
            builder.RegisterType<EditBookModel>().AsSelf();
            builder.RegisterType<CreateAuthorModel>().AsSelf();
            builder.RegisterType<CreateBookModel>().AsSelf();

            base.Load(builder);
        }
    }
}
