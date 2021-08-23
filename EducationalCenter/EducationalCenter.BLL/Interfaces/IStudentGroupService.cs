using EducationalCenter.Common.Dtos.StudentGroup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationalCenter.BLL.Interfaces
{
    public interface IStudentGroupService
    {
        Task<IEnumerable<StudentGroupDTO>> GetAllAsync();
        Task CreateAsync(StudentGroupFullInfoDTO studentCreationDto);
        Task<StudentGroupFullInfoDTO> FindByIdAsync(int id);
        Task UpdateAsync(StudentGroupFullInfoDTO studentUpdationDto);
        Task DeleteAsync(int id);
    }
}
