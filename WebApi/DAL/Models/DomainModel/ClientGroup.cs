using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DAL.Models.DomainModel
{
    public class ClientGroup
    {   
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
