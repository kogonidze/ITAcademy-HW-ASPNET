using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalCenter.DataAccess.EF.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(EducationalCenterContext context)
            : base(context)
        {

        }

        public async new Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _dbSet.Include(x => x.Group).ToListAsync();
        }
    }
}
