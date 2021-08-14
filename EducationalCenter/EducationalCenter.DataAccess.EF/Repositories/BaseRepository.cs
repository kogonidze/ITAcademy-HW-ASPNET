using System;
using System.Collections.Generic;
using System.Linq;
using EducationalCenter.DataAccess.EF.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EducationalCenter.DataAccess.EF.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private EducationalCenterContext _context;
        private DbSet<TEntity> _dbSet;

        public BaseRepository(EducationalCenterContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();

            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetByFilter(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
    }
}
