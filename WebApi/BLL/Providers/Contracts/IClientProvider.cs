using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAL.Models.DomainModel;

namespace WebApi.BLL.Providers.Contracts
{
    public interface IClientProvider
    {
        Task<ICollection<Client>> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task<bool> RemoveClientAsync(int id);
        Task<Client> CreateClientAsync(Client group);
        Task<Client> EditClientAsync(Client group);
    }
}
