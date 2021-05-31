using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    /// <summary>
    /// A specialization of IRepositoryBase, to be used for Game-related database operations
    /// </summary>
    public interface IGameRepository : IRepositoryBase<Game>
    {
        
    }
}
