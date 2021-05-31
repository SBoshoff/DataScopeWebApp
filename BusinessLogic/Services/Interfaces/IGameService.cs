using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Interfaces
{
    /// <summary>
    /// Interface for GameService. Meant to bridge controller and repository
    /// </summary>
    public interface IGameService
    {
        /// <summary>
        /// Gets paged list of games
        /// </summary>
        /// <param name="pageSize">Size of page. Must be greater than 0</param>
        /// <param name="pageNum">Page number. Must be greater than 0</param>
        /// <returns>A GamePageData object</returns>
        public Task<GamePageData> GetPagedListOfGames(int pageSize, int pageNum);
        /// <summary>
        /// Gets a single game by ID
        /// </summary>
        /// <param name="id">The ID of the game to search for</param>
        /// <returns>A Game object</returns>
        public Task<Game> GetGameById(int id);
        /// <summary>
        /// Gets a list of games whose name includes the argument
        /// Useful for filtering by name
        /// </summary>
        /// <param name="name">The name of the filter</param>
        /// <returns>A paged list of games</returns>
        public Task<GamePageData> GetGamesByName(string name);
        /// <summary>
        /// Adds a game to the database
        /// </summary>
        /// <param name="game">The game to add. Must not include an ID</param>
        /// <returns>The newly-added Game object</returns>
        public Task<Game> AddGame(Game game);
        /// <summary>
        /// Updates a game
        /// </summary>
        /// <param name="game">The game to be updated. Must include an ID</param>
        /// <returns>The updated Game object</returns>
        public Task<Game> UpdateGame(Game game);
        /// <summary>
        /// Deletes a game by ID
        /// </summary>
        /// <param name="gameId">The ID of the game to delete</param>
        /// <returns>The deleted Game object</returns>
        public Task<Game> DeleteGame(int gameId);
    }
}
