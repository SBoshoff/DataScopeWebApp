using DAL.Context;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity: class, new()
    {
        protected readonly AppDbContext _context;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> GetPagedList(int pageSize, int pageNum)
        {
            return await _context.Set<TEntity>().Skip((pageSize * pageNum) - pageSize).Take(pageSize).DefaultIfEmpty().ToListAsync();
        }
        public async Task<List<TEntity>> GetList()
        {
            return await _context.Set<TEntity>().DefaultIfEmpty().ToListAsync();
        }
        public async Task<TEntity> Get(int id)
        {
            return await _context.FindAsync<TEntity>(id);
        }
        public async Task<TEntity> Insert(TEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> Delete(int id)
        {
            TEntity toDelete = _context.Find<TEntity>(id);
            if (toDelete == null)
            {
                return toDelete;
            }

            _context.Remove(toDelete);
            await _context.SaveChangesAsync();
            return toDelete;
        }
    }
}
