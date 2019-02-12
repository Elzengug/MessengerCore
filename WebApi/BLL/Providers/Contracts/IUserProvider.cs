using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAL.Models.DomainModel.Auth;

namespace WebApi.BLL.Providers.Contracts
{
    public interface IUserProvider
    {
        Task<ICollection<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserAsync(string email, string password);
        Task<bool> RemoveUserAsync(int id);
        Task<User> CreateUserAsync(User client);
        Task<User> EditUserAsync(User client);
    }
}
