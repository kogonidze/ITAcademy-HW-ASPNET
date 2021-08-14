using System;
using EducationalCenter.Common.Enums;

namespace EducationalCenter.Common.Dtos.Student
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string FIO { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Faculty Faculty { get; set; }
        public int EnrollmentYear { get; set; }
    }
}
