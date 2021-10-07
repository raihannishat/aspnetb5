using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataImporter.Library.BusinessObjects;
using DataImporter.Library.UnitOfWorks;

namespace DataImporter.Library.Services
{
    public class GroupService : IGroupService
    {
        private readonly IDataImporterUnitOfWork _dataImporterUnitOfWork;
        private readonly IMapper _mapper;

        public GroupService(IDataImporterUnitOfWork dataImporterUnitOfWork, IMapper mapper)
        {
            _dataImporterUnitOfWork = dataImporterUnitOfWork;
            _mapper = mapper;
        }

        public void CreateGroup(Group group)
        {
            _dataImporterUnitOfWork
                .GroupRepository
                .Add(_mapper.Map<Entities.Group>(group));

            _dataImporterUnitOfWork.Save();
        }

        public void DeleteGroup(int groupId)
        {
            _dataImporterUnitOfWork
                .GroupRepository
                .Remove(groupId);
            
            _dataImporterUnitOfWork.Save();
        }

        public Group GetGroup(int id)
        {
            var group = _dataImporterUnitOfWork
                .GroupRepository
                .GetById(id);

            if (group == null) return null;

            return _mapper.Map<Group>(group);
        }

        public (IList<Group> records, int total, int totalDisplay)
            GetGroups(int pageIndex, int pageSize, string searchText, string sortText, Guid userId)
        {
            var teamData = _dataImporterUnitOfWork.GroupRepository
                .GetDynamic(string.IsNullOrWhiteSpace(searchText) ? 
                u => u.ApplicationUserId == userId : 
                x => x.Name.Contains(searchText), sortText, string.Empty, pageIndex, pageSize);

            var result = (from item in teamData.data
                          select _mapper.Map<Group>(item)).ToList();

            return (result, teamData.total, teamData.totalDisplay);
        }

        public void UpdateGroup(Group group)
        {
            var groupEntity = _dataImporterUnitOfWork
                .GroupRepository
                .GetById(group.Id);

            if (groupEntity != null)
            {
                _mapper.Map(group, groupEntity);
                _dataImporterUnitOfWork.Save();
            }
            else
            {
                throw new InvalidOperationException("Could not find Group");
            }
        }
    }
}
