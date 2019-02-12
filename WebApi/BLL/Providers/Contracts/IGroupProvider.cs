using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAL.Models.DomainModel;

namespace WebApi.BLL.Providers.Contracts
{
    public interface IGroupProvider
    {
        Task<ICollection<Group>> GetAllGroupsAsync();
        Task<Group> GetGroupByIdAsync(int id);
        Task<bool> RemoveGroupAsync(int id);
        Task<Group> CreateGroupAsync(Group group);
        Task<Group> EditGroupAsync(Group group);
    }
}
