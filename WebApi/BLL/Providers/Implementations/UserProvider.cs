using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.BLL.Providers.Contracts;
using WebApi.DAL.Data.Repositories.Contracts;
using WebApi.DAL.Models.DomainModel.Auth;

namespace WebApi.BLL.Providers.Implementations
{
    public class UserProvider : IUserProvider
    {

        private readonly IUserRepository _userRepository;

        public UserProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ICollection<User>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetItemsAsync();
            return users;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.FindFirstAsync(b => b.Id == id);
            return user;
        }

        public async Task<User> GetUserAsync(string email, string password)
        {
            var user = await _userRepository.FindFirstAsync(b => b.Email == email && b.Password == password);
            return user;
        }

        public async Task<bool> RemoveUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id);
            return await _userRepository.RemoveAsync(user);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var addedUser = await _userRepository.AddAsync(user);
            return addedUser;
        }

        public async Task<User> EditUserAsync(User user)
        {
            var editUser = await _userRepository.UpdateAsync(user);
            return editUser;
        }
    }
}
