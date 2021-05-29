using BusinessLogic.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataScopeWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameService _gameService;

        public GameController(ILogger<GameController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        [HttpGet("pagedList")]
        public async Task<List<Game>> GetPagedList(int pageSize, int pageNum)
        {
            List<Game> games = new List<Game>();
            try
            {
                games = await _gameService.GetPagedListOfGames(pageSize, pageNum);
                return games;
            }
            catch(Exception e)
            {
                _logger.LogError($"An exception has occurred: ${e.Message}");
                return games;
            }
        }

        [HttpGet("getById")]
        public async Task<Game> GetById(int id)
        {
            Game game = new Game();
            try
            {
                game = await _gameService.GetGameById(id);
            }
            catch (Exception e)
            {
                _logger.LogError($"An exception has occurred: ${e.Message}");
            }
            return game;
        }

        [HttpGet("getByName")]
        public async Task<Game> GetByName(string name)
        {
            Game game = new Game();
            try
            {
                game = await _gameService.GetGameByName(name);
            }
            catch (Exception e)
            {
                _logger.LogError($"An exception has occurred: ${e.Message}");
            }
            return game;
        }

        [HttpPost("addGame")]
        public async Task<Game> AddGame(Game game)
        {
            try
            {
                game = await _gameService.AddGame(game);
            }
            catch (Exception e)
            {
                _logger.LogError($"An exception has occurred: ${e.Message}");
            }
            return game;
        }

        [HttpPut("updateGame")]
        public async Task<Game> UpdateGame(Game game)
        {
            try
            {
                game = await _gameService.UpdateGame(game);
            }
            catch (Exception e)
            {
                _logger.LogError($"An exception has occurred: ${e.Message}");
            }
            return game;
        }

        [HttpDelete("deleteGame")]
        public async Task<bool> DeleteGame(int id)
        {
            try
            {
                Game game = await _gameService.DeleteGame(id);
                _logger.LogInformation($"Deleted game: id {game.id}, name {game.Name}");
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError($"An exception has occurred: ${e.Message}");
                return false;
            }
        }
    }
}
