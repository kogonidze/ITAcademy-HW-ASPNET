using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalCenter.DataAccess.EF.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetByFilterAsync(Func<TEntity, bool> predicate);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
        void Dispose();
    }
}
