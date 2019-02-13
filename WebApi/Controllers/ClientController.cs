using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.BLL.Providers.Contracts;
using WebApi.DAL.Models.DomainModel;
using WebApi.ViewModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientGroupProvider _clientGroupProvider;
        private readonly IClientProvider _clientProvider;
        public ClientController(IClientGroupProvider clientGroupProvider, IClientProvider clientProvider)
        {
            _clientGroupProvider = clientGroupProvider;
            _clientProvider = clientProvider;
        }

        [HttpPost]
        [Route("CreateClient")]
        public async Task<IActionResult> CreateGroup(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                Client client = new Client
                {
                    Name = model.Name,
                    Email = model.Email
                };
                await _clientProvider.CreateClientAsync(client);
            }
            return Ok();
        }
        [HttpGet]
        [Route("GetAllClients")]
        public async Task<IActionResult> GetAllGroups()
        {
            ICollection<Client> clients = await _clientProvider.GetAllClientsAsync();
            return Ok(clients);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientProvider.RemoveClientAsync(id);
            return Ok();
        }
        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(ClientViewModel model)
        {
            var client = await _clientProvider.GetClientByIdAsync(model.Id);
            client.Name = model.Name;
            client.Email = model.Email;
            await _clientProvider.EditClientAsync(client);
            return Ok();
        }
    }
}