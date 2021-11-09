using System.Collections.Generic;
using System.Threading.Tasks;
using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Dtos.Api.Request;

namespace EducationalCenter.BLL.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllAsync(int page = 1, int pageSize = 20);
        Task CreateAsync(StudentFullInfoDTO studentCreationDto);
        Task<StudentFullInfoDTO> FindByIdAsync(int id);
        Task UpdateAsync(StudentFullInfoDTO studentUpdationDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<StudentDTO>> GetByFilterAsync(GetFilteredStudentsRequest filter);
        int Count();
        Task<int> CountWithFilter(GetFilteredStudentsRequest filter);
    }
}
