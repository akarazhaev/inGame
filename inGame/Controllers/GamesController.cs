using inGame.Interfaces;
using inGame.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;
        public GamesController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        [HttpGet("AllGames")]
        public async Task<ActionResult<IEnumerable<Game>>> AllGames()
        {
            var games = await _gameRepository.GetAllAsync();
            return Ok(games);
        }
        [HttpGet("Game/{id}")]
        public async Task<ActionResult<Game>> GameById(int id)
        {
            var game = await _gameRepository.GetGameById(id);
            if (game == null)
                return NotFound();
            return Ok(game);
        }
        [HttpGet("Games/ByGenres/{id}")]
        public async Task<ActionResult<IEnumerable<Game>>> GamesByGenre(int id)
        {
            var games = await _gameRepository.GetGamesByGenreId(id);
            if (games.Count() == 0)
                return Ok(games);
            return Ok(games);
        }
        [HttpPost("AddGameToList"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddGameToList(Game game)
        {
            if (game == null)
                return BadRequest("Error!");
            _gameRepository.Add(game);
            return Ok("Game is added");
        }
        [HttpPut("UpdateGameFromList"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateGame(int id, Game request)
        {
            var game = await _gameRepository.GetGameById(id);
            if (game == null)
                return NotFound();
            game.Title = request.Title;
            game.Description = request.Description;
            game.Genre = request.Genre;
            game.Raking = request.Raking;
            _gameRepository.Update(game);
            return Ok("Game updated");
        }
        [HttpDelete("DeleteGameFromList"), Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteGame(int id)
        {
            var game = await _gameRepository.GetGameById(id);
            if (game == null)
                return NotFound();
            _gameRepository.Delete(game);
            return Ok("Game deleted");
        }
    }
}
