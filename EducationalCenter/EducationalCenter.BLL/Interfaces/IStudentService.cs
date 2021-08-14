using System.Collections.Generic;
using System.Threading.Tasks;
using EducationalCenter.Common.Dtos.Student;

namespace EducationalCenter.BLL.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task CreateAsync(StudentCreationDTO studentCreationDto);
        Task<StudentFullInfoDTO> FindByIdAsync(int id);
        Task UpdateAsync(StudentFullInfoDTO studentUpdationDto);
        Task DeleteAsync(int id);
    }
}
