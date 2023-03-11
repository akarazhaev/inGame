using inGame.Models;

namespace inGame.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByJwtTokenAsync(string token);
        bool Add(User user);
        bool Update(User user);
        bool Delete(User user);
        bool Save();
    }
}
