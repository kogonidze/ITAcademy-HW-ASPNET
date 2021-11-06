using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Dtos.Api.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalCenter.BLL.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDTO>> GetAllAsync();
        Task<TeacherFullInfoDTO> FindByIdAsync(int id);
        Task<IEnumerable<TeacherDTO>> GetByFilterAsync(GetFilteredTeachersRequest filter);
        Task CreateAsync(TeacherFullInfoDTO teacherCreationDto);
        Task UpdateAsync(TeacherFullInfoDTO teacherUpdationDto);
        Task DeleteAsync(int id);
    }
}
