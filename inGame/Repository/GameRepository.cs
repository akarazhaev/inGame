using inGame.Data;
using inGame.Interfaces;
using inGame.Models;
using Microsoft.EntityFrameworkCore;

namespace inGame.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;
        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Game game)
        {
            _context.Games.Add(game);
            return Save();
        }

        public bool Delete(Game game)
        {
            _context.Games.Remove(game);
            return Save();
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            var games = await _context.Games.ToListAsync();
            return games;
        }

        public async Task<Game> GetGameById(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
            return game;
        }

        public async Task<IEnumerable<Game>> GetGamesByGenreId(int id)
        {
            var games = await _context.Games.Where(g => g.GenreId == id).ToListAsync();
            return games;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Game game)
        {
            _context.Games.Update(game);
            return Save();
        }
    }
}
