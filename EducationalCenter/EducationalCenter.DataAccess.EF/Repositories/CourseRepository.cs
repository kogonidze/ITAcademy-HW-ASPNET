using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;

namespace EducationalCenter.DataAccess.EF.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(EducationalCenterContext context) :
            base(context)
        {

        }
    }
}
