using System;
using EducationalCenter.Common.Enums;

namespace EducationalCenter.SL.DTO
{
    public class StudentDTO
    {
        public string FIO { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Faculty Faculty { get; set; }
        public int EnrollmentYear { get; set; }
    }
}
