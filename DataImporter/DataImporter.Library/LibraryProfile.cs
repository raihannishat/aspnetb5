using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity = DataImporter.Library.Entities;
using BusinessObject = DataImporter.Library.BusinessObjects;

namespace DataImporter.Library
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            CreateMap<Entity.Content, BusinessObject.Content>().ReverseMap();
            CreateMap<Entity.ExcelFile, BusinessObject.ExcelFile>().ReverseMap();
            CreateMap<Entity.Group, BusinessObject.Group>().ReverseMap();
        }
    }
}
