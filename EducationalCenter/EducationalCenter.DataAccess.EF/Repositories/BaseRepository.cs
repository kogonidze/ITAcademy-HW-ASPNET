using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EducationalCenter.DataAccess.EF.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationalCenter.DataAccess.EF.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected EducationalCenterContext _context;
        protected DbSet<TEntity> _dbSet;

        public BaseRepository(EducationalCenterContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet
                            .AsQueryable()
                            .Where(predicate)
                            .ToListAsync();
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var item = _dbSet.Find(id);

            _dbSet.Remove(item);
        }

        public void Dispose() { }
    }
}
