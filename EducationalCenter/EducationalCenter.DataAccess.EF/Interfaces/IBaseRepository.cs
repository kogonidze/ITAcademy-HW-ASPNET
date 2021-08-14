using System;
using System.Collections.Generic;

namespace EducationalCenter.DataAccess.EF.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        IEnumerable<TEntity> GetByFilter(Func<TEntity, bool> predicate);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
}
