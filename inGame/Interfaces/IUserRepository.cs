using inGame.Models;

namespace inGame.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        bool Add(User user);
        bool Update(User user);
        bool Delete(User user);
        bool Save();
    }
}
