using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAL.Data.Contracts;
using WebApi.DAL.Data.Repositories.Contracts;
using WebApi.DAL.Models.DomainModel;

namespace WebApi.DAL.Data.Repositories.Implementations
{
    public class ClientMessageRepository : GenericRepository<ClientMessage>, IClientMessageRepository
    {
        public ClientMessageRepository(IDbContext dbContext): base(dbContext)
        {

        }
    }
}
