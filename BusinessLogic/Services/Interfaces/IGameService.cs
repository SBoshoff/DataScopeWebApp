using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    public interface IGameService
    {
        public Task<GamePageData> GetPagedListOfGames(int pageSize, int pageNum);
        public Task<Game> GetGameById(int id);
        public Task<Game> GetGameByName(string name);
        public Task<Game> AddGame(Game game);
        public Task<Game> UpdateGame(Game game);
        public Task<Game> DeleteGame(int gameId);
    }
}
