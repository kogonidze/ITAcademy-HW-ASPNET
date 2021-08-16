using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;

namespace EducationalCenter.DataAccess.EF.Repositories
{
    public class StudentGroupRepository : BaseRepository<StudentGroup>, IStudentGroupRepository
    {
        public StudentGroupRepository(EducationalCenterContext context) :
            base(context)
        {

        }
    }
}
