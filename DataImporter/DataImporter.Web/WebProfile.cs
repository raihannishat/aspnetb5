using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataImporter.Library.BusinessObjects;
using DataImporter.Web.Models.Groups;
using DataImporter.Web.Models.Imports;

namespace DataImporter.Web
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<CreateGroupModel, Group>().ReverseMap();
            CreateMap<EditGroupModel, Group>().ReverseMap();
            CreateMap<CreateImportModel, ImportExcelFile>().ReverseMap();
        }
    }
}
