using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BLL.Providers.Contracts;
using WebApi.DAL.Data.Repositories.Contracts;
using WebApi.DAL.Models.DomainModel;

namespace WebApi.BLL.Providers.Implementations
{
    public class GroupProvider : IGroupProvider
    {
        private readonly IGroupRepository _groupRepository;

        public GroupProvider(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public async Task<ICollection<Group>> GetAllGroupsAsync()
        {
            var groups = await _groupRepository.GetItemsAsync();
            return groups;
        }

        public async Task<Group> GetGroupByIdAsync(int id)
        {
            var group = await _groupRepository.FindFirstAsync(b => b.Id == id);
            return group;
        }

        public async Task<bool> RemoveGroupAsync(int id)
        {
            var group = await GetGroupByIdAsync(id);
            return await _groupRepository.RemoveAsync(group);
        }

        public async Task<Group> CreateGroupAsync(Group group)
        {
            var addedGroup = await _groupRepository.AddAsync(group);
            return addedGroup ;
        }

        public async Task<Group> EditGroupAsync(Group group)
        {
            var editGroup = await _groupRepository.UpdateAsync(group);
            return editGroup;
        }
    }
    
}
