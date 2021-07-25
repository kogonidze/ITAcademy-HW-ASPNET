using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationalCenter.SL.DTO;

namespace EducationalCenter.ISL
{
    public interface IStudentService
    {
        IEnumerable<StudentDTO> GetAll();
    }
}
