using PlomesApi.Models;

namespace PlomesApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();

        Task<User> GetById(int id);

        Task<User> Save(User user);

        Task<User> Update(User user);

        Task delete(int id);
    }
}
