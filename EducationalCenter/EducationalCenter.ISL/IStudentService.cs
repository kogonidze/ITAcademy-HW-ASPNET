using System.Collections.Generic;
using EducationalCenter.SL.DTO;

namespace EducationalCenter.ISL
{
    public interface IStudentService
    {
        IEnumerable<StudentDTO> GetAll();
        void Create(StudentCreationDTO studentCreationDto);
        StudentUpdationDTO FindById(int id);

        void Update(StudentUpdationDTO studentUpdationDto);
    }
}
