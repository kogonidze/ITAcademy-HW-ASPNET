using EducationalCenter.Common.Dtos.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalCenter.BLL.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetAllAsync();
        Task CreateAsync(CourseFullInfoDTO courseCreationDto);
        Task<CourseFullInfoDTO> FindByIdAsync(int id);
        Task UpdateAsync(CourseFullInfoDTO courseUpdationDto);
        Task DeleteAsync(int id);
    }
}
