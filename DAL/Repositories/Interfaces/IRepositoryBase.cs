using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    /// <summary>
    /// An abstract interface to be used by specialized repositories
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Return a paged list of T Objects
        /// </summary>
        /// <param name="pageSize">The page size. Must be greater than 0</param>
        /// <param name="pageNum">The page number. Must be greater than 0</param>
        /// <returns>A list of type T</returns>
        public Task<List<T>> GetPagedList(int pageSize, int pageNum);
        /// <summary>
        /// Returns all T objects in the database
        /// </summary>
        /// <returns>A list of type T</returns>
        public Task<List<T>> GetList();
        /// <summary>
        /// Gets an object based on an ID
        /// </summary>
        /// <param name="id">The ID to search for</param>
        /// <returns>An object</returns>
        public Task<T> Get(int id);
        /// <summary>
        /// Inserts an object into the database
        /// </summary>
        /// <param name="Entity">The object to insert</param>
        /// <returns>The inserted object</returns>
        public Task<T> Insert(T Entity);
        /// <summary>
        /// Updates an object in the database
        /// </summary>
        /// <param name="Entity">The object to update</param>
        /// <returns>The updated object</returns>
        public Task<T> Update(T Entity);
        /// <summary>
        /// Hard-deletes an object from the database
        /// </summary>
        /// <param name="id">The unique ID of the object</param>
        /// <returns>The deleted object</returns>
        public Task<T> Delete(int id);
    }
}
