using System.Collections.Generic;
using System.Threading.Tasks;
using EducationalCenter.Common.Dtos;

namespace EducationalCenter.BLL.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task CreateAsync(StudentFullInfoDTO studentCreationDto);
        Task<StudentFullInfoDTO> FindByIdAsync(int id);
        Task UpdateAsync(StudentFullInfoDTO studentUpdationDto);
        Task DeleteAsync(int id);
    }
}
