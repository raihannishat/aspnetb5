using Autofac;
using AutoMapper;
using DataImporter.Library.Services;
using DataImporter.Library.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Web.Models.Groups
{
    public class EditGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid ApplicationUserId { get; set; }

        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public EditGroupModel()
        {
            _groupService = Startup.AutofacContainer.Resolve<IGroupService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

        public void LoadModelData(int id)
        {
            _mapper.Map(_groupService.GetGroup(id), this);
        }

        public void Update()
        {
            _groupService.UpdateGroup(_mapper.Map(this, new Group()));
        }
    }
}
