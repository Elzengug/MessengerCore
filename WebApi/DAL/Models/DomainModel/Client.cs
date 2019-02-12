using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAL.Models.DomainModel.Base;

namespace WebApi.DAL.Models.DomainModel
{
    public class Client : BaseModel<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<ClientGroup> ClientGroups { get; set; }
        public ICollection<ClientMessage> ClientMessages { get; set; }
    }
}
