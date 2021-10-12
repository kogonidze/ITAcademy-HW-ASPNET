using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalCenter.DataAccess.EF.Repositories
{
    public class StudentGroupRepository : BaseRepository<StudentGroup>, IStudentGroupRepository
    {
        public StudentGroupRepository(EducationalCenterContext context) :
            base(context)
        {

        }

        public async new Task<IEnumerable<StudentGroup>> GetAllAsync()
        {
            return await _dbSet.Include(x => x.Faculty).ToListAsync();
        }

        public async new Task<StudentGroup> GetByIdAsync(int id)
        {
            return await _dbSet.Include(x => x.Faculty).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
