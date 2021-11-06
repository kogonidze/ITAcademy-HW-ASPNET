﻿using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationalCenter.DataAccess.EF.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(EducationalCenterContext context)
            : base(context)
        {

        }

        public async new Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _dbSet.Include(x => x.Department).ToListAsync();
        }

        public async new Task<Teacher> GetByIdAsync(int id)
        {
            return await _dbSet.Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async new Task<IEnumerable<Teacher>> GetByFilterAsync(Expression<Func<Teacher, bool>> predicate)
        {
            return await _dbSet
                            .AsQueryable()
                            .Include(x => x.Department)
                            .Where(predicate)
                            .ToListAsync();
        }
    }
}
