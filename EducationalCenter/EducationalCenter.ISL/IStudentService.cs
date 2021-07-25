using System.Collections.Generic;
using EducationalCenter.SL.DTO;

namespace EducationalCenter.ISL
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
