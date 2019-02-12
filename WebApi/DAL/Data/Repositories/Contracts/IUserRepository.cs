using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAL.Models.DomainModel.Auth;

namespace WebApi.DAL.Data.Repositories.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
