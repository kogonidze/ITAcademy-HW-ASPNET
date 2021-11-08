using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationalCenter.DataAccess.EF.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(int page = 1, int pageSize = 20);
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate, int page = 1, int pageSize = 20);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
        void Dispose();
        int Count();
        Task<int> CountWithFilter(Expression<Func<TEntity, bool>> predicate);
    }
}
