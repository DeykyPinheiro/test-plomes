using PlomesApi.Models;
using PlomesApi.Repositories.Interfaces;
using PlomesApi.Services.Interfaces;

namespace PlomesApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task delete(int id)
        {
            await _userRepository.delete(id);
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> Save(User user)
        {
            return await _userRepository.Save(user);
        }

        public async Task<User> Update(int id, User user)
        {
            return await _userRepository.Update(new User(id, user));
        }
    }
}
