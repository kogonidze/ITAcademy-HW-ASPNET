using System.Collections.Generic;
using EducationalCenter.Common.Dtos.Student;

namespace EducationalCenter.BLL.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentDTO> GetAll();
        void Create(StudentCreationDTO studentCreationDto);
        StudentFullInfoDTO FindById(int id);
        void Update(StudentFullInfoDTO studentUpdationDto);
        void Delete(StudentFullInfoDTO studentDeletionDto);
    }
}
