using BusinessLogic.Services.Interfaces;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BusinessLogic.Services
{
    public class GameService : IGameService
    {
        private ILogger _logger;
        private IGameRepository _gameRepository;

        public GameService(ILogger logger, IGameRepository gameRepository)
        {
            _logger = logger;
            _gameRepository = gameRepository;
        }
        public async Task<Game> AddGame(Game game)
        {
            return await _gameRepository.Insert(game);
        }

        public async Task<Game> DeleteGame(int gameId)
        {
            return await _gameRepository.Delete(gameId);
        }

        public async Task<Game> GetGameById(int id)
        {
            return await _gameRepository.Get(id);
        }

        public async Task<GamePageData> GetGamesByName(string name)
        {
            GamePageData pageData = new GamePageData();
            pageData.AllGamesCount = _gameRepository.GetList().Result.Count();
            var list = await _gameRepository.GetList();
            pageData.Games = list.Where(g => g.Name.ToLower().Contains(name.ToLower())).ToList();
            return pageData;
        }

        public async Task<GamePageData> GetPagedListOfGames(int pageSize, int pageNum)
        {
            GamePageData pageData = new GamePageData();
            pageData.AllGamesCount = _gameRepository.GetList().Result.Count();
            pageData.Games = await _gameRepository.GetPagedList(pageSize, pageNum);
            return pageData;
        }

        public async Task<Game> UpdateGame(Game game)
        {
            return await _gameRepository.Update(game);
        }
    }
}
