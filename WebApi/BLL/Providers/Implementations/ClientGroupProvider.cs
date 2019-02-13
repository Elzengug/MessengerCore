using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BLL.Providers.Contracts;
using WebApi.DAL.Data.Repositories.Contracts;
using WebApi.DAL.Models.DomainModel;

namespace WebApi.BLL.Providers.Implementations
{
    public class ClientGroupProvider : IClientGroupProvider
    {
        private readonly IClientGroupRepository _clientGroupRepository;

        public ClientGroupProvider(IClientGroupRepository clientGroupRepository)
        {
            _clientGroupRepository = clientGroupRepository;
        }
        public async Task<ICollection<ClientGroup>> GetAllClientGroupsAsync()
        {
            var clientGroups = await _clientGroupRepository.GetItemsAsync();
            return clientGroups;
        }

        public async Task<ClientGroup> GetClientGroupByIdAsync(int clientid, int groupId)
        {
            var clientGroup = await _clientGroupRepository.FindFirstAsync(b => b.ClientId == clientid && b.GroupId == groupId);
            return clientGroup;
        }

        public async Task<bool> RemoveClientGroupAsync(int clientid, int groupId)
        {
            var clientGroup = await GetClientGroupByIdAsync(clientid, groupId);
            return await _clientGroupRepository.RemoveAsync(clientGroup);
        }

        public async Task<ClientGroup> CreateClientGroupAsync(ClientGroup clientGroup)
        {
            var addedClientGroup = await _clientGroupRepository.AddAsync(clientGroup);
            return addedClientGroup;
        }

        public async Task<ClientGroup> EditClientGroupAsync(ClientGroup clientGroup)
        {
            var editClientGroup = await _clientGroupRepository.UpdateAsync(clientGroup);
            return editClientGroup;
        }
    }
}
