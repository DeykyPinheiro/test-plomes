using Microsoft.EntityFrameworkCore;
using PlomesApi.Data;
using PlomesApi.Models;
using PlomesApi.Repositories.Interfaces;

namespace PlomesApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Users
                         .ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Id == id);

        }



        public async Task<User> Save(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> Update(User user)
        {

            User userId = await GetById(user.Id);

            if (userId == null)
            {
                throw new Exception($"Usuario de Id: {user.Id} não Encontrado.");
            }

            userId.Name = user.Name;
            userId.Email = user.Email;

            _dbContext.Update(userId);
            await _dbContext.SaveChangesAsync();

            return userId;
        }

        public async Task delete(int id)
        {
            User userId = await GetById(id);

            if (userId == null)
            {
                throw new Exception($"Usuario de Id: {id} não Encontrado.");
            }

            _dbContext.Users.Remove(userId);
            _dbContext.SaveChanges();
        }

    }
}
