using EducationalCenter.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalCenter.BLL.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDTO>> GetAllAsync();
        Task CreateAsync(DepartmentDTO departmentCreationDto);
        Task<DepartmentDTO> FindByIdAsync(int id);
        Task UpdateAsync(DepartmentDTO departmentUpdationDto);
        Task DeleteAsync(int id);
    }
}
