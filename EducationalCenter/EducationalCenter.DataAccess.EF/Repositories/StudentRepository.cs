using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;

namespace EducationalCenter.DataAccess.EF.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(EducationalCenterContext context)
            : base(context)
        {

        }
    }
}
