using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DAL.Models.DomainModel
{
    public class ClientMessage
    {
        public int MessageId { get; set; }
        public Message Message { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
