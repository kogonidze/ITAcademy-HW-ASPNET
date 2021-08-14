using System;
using EducationalCenter.Common.Enums;

namespace EducationalCenter.Common.Dtos.Student
{
    public class StudentFullInfoDTO
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Faculty Faculty { get; set; }
        public int EnrollmentYear { get; set; }
    }
}
