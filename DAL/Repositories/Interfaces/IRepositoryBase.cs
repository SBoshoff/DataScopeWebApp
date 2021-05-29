using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IRepositoryBase<T>
    {
        public Task<List<T>> GetPagedList(int pageSize, int pageNum);
        public Task<List<T>> GetList();
        public Task<T> Get(int id);
        public Task<T> Insert(T Entity);
        public Task<T> Update(T Entity);
        public Task<T> Delete(int id);
    }
}
