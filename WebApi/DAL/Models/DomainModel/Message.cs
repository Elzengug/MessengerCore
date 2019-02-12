using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAL.Models.DomainModel.Base;

namespace WebApi.DAL.Models.DomainModel
{
    public class Message : BaseModel<int>
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public ICollection<ClientMessage> ClientMessages { get; set; }
    }
}
