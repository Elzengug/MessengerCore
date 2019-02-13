using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BLL.Providers.Contracts;
using WebApi.DAL.Data.Repositories.Contracts;
using WebApi.DAL.Models.DomainModel;

namespace WebApi.BLL.Providers.Implementations
{
    public class ClientProvider: IClientProvider
    {
        private readonly IClientRepository _clientRepository;

        public ClientProvider(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<ICollection<Client>> GetAllClientsAsync()
        {
            var clients = await _clientRepository.GetItemsAsync();
            return clients;
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            var client = await _clientRepository.FindFirstAsync(b => b.Id == id);
            return client;
        }

        public async Task<bool> RemoveClientAsync(int id)
        {
            var client = await GetClientByIdAsync(id);
            return await _clientRepository.RemoveAsync(client);
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            var addedClient = await _clientRepository.AddAsync(client);
            return addedClient;
        }

        public async Task<Client> EditClientAsync(Client client)
        {
            var editClient = await _clientRepository.UpdateAsync(client);
            return editClient;
        }
    }
}

