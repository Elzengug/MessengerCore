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
    public class GroupController : ControllerBase
    {
        private readonly IGroupProvider _groupProvider;
        public GroupController(IGroupProvider groupProvider)
        {
            _groupProvider = groupProvider;
        }

        [HttpPost]
        [Route("CreateGroup")]
        public async Task<IActionResult> CreateGroup (GroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                Group group = new Group
                {
                    Name = model.Name
                };
                await _groupProvider.CreateGroupAsync(group);
            }
            return Ok();
        }
        [HttpGet]
        [Route("GetAllGroups")]
        public async Task<IActionResult> GetAllGroups()
        {
            ICollection<Group> groups = await _groupProvider.GetAllGroupsAsync();
            return Ok(groups);
        }
    }
}