using EducationalCenter.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalCenter.BLL.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDTO>> GetAllAsync();
        Task CreateAsync(TeacherFullInfoDTO teacherCreationDto);
        Task<TeacherFullInfoDTO> FindByIdAsync(int id);
        Task UpdateAsync(TeacherFullInfoDTO teacherUpdationDto);
        Task DeleteAsync(int id);
    }
}
