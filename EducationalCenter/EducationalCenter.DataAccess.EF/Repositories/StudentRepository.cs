using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationalCenter.DataAccess.EF.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(EducationalCenterContext context)
            : base(context)
        {

        }

        public async new Task<IEnumerable<Student>> GetAllAsync(int page = 1, int pageSize = 20)
        {
            return await _dbSet
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(x => x.Group)
                .ToListAsync();
        }

        public async new Task<IEnumerable<Student>> GetByFilterAsync(Expression<Func<Student, bool>> predicate, int page = 1, int pageSize = 20)
        {
            return await _dbSet
                            .AsQueryable()
                            .Include(x => x.Group)
                            .Where(predicate)
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();
        }
    }
}
