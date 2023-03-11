using inGame.Models;

namespace inGame.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game> GetGameById(int id);
        bool Add(Game game);
        bool Update(Game game);
        bool Delete(Game game);
        bool Save();
    }
}
