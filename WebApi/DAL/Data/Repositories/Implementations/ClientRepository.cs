using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAL.Data.Contracts;
using WebApi.DAL.Data.Repositories.Contracts;
using WebApi.DAL.Models.DomainModel;

namespace WebApi.DAL.Data.Repositories.Implementations
{
    public class ClientRepository : GenericRepository<Client> , IClientRepository
    {
        public ClientRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
