using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataImporter.Library.BusinessObjects;
using DataImporter.Library.Services;
using Autofac;
using AutoMapper;

namespace DataImporter.Web.Models.Groups
{
    public class CreateGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid ApplicationUserId { get; set; }

        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public CreateGroupModel()
        {
            _groupService = Startup.AutofacContainer.Resolve<IGroupService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public CreateGroupModel(IGroupService groupService)
        {
            _groupService = groupService;
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public void Create()
        {
            _groupService.CreateGroup(_mapper.Map<Group>(this));
        }
    }
}
