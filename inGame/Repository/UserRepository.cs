using inGame.Data;
using inGame.Interfaces;
using inGame.Models;
using Microsoft.EntityFrameworkCore;

namespace inGame.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(User user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public bool Delete(User user)
        {
            _context.Users.Remove(user);
            return Save();
        }

        public async Task<User> GetByJwtTokenAsync(string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken ==  token);
            return user;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            return user;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(User user)
        {
            _context.Users.Update(user);
            return Save();
        }
    }
}
