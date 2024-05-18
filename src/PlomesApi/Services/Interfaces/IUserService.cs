using PlomesApi.Models;

namespace PlomesApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();

        Task<User> GetById(int id);

        Task<User> Save(User user);

        Task<User> Update(int id, User user);

        Task delete(int id);
    }
}
