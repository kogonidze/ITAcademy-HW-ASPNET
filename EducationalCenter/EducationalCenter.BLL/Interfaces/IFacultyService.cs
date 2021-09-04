using EducationalCenter.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalCenter.BLL.Interfaces
{
    public interface IFacultyService
    {
        Task<IEnumerable<FacultyDTO>> GetAllAsync();
        Task CreateAsync(FacultyDTO facultyCreationDto);
        Task<FacultyDTO> FindByIdAsync(int id);
        Task UpdateAsync(FacultyDTO facultyUpdationDto);
        Task DeleteAsync(int id);
    }
}
