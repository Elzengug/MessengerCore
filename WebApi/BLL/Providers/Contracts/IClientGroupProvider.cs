using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAL.Models.DomainModel;

namespace WebApi.BLL.Providers.Contracts
{
    public interface IClientGroupProvider
    {
        Task<ICollection<ClientGroup>> GetAllClientGroupsAsync();
        Task<ClientGroup> GetClientGroupByIdAsync(int clientid, int groupId);
        Task<bool> RemoveClientGroupAsync(int clientid, int groupId);
        Task<ClientGroup> CreateClientGroupAsync(ClientGroup group);
        Task<ClientGroup> EditClientGroupAsync(ClientGroup group);
    }
}
