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
            CreateMap<Entity.ExcelColumn, BusinessObject.ExcelColumn>().ReverseMap();
            CreateMap<Entity.ExcelRow, BusinessObject.ExcelRow>().ReverseMap();
            CreateMap<Entity.Group, BusinessObject.Group>().ReverseMap();
            CreateMap<Entity.ExportExcelFile, BusinessObject.ExportExcelFile>().ReverseMap();
            CreateMap<Entity.ImportExcelFile, BusinessObject.ImportExcelFile>().ReverseMap();
        }
    }
}
