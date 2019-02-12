using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAL.Data.Contracts;
using WebApi.DAL.Data.Repositories.Contracts;
using WebApi.DAL.Models.DomainModel;

namespace WebApi.DAL.Data.Repositories.Implementations
{
    public class StateRepository : GenericRepository<Status>, IStatusRepository
    {
        public StateRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
