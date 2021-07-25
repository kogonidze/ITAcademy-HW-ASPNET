using System;
using EducationalCenter.Common.Enums;

namespace EducationalCenter.SL.DTO
{
    public class StudentCreationDTO
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Faculty Faculty { get; set; }
        public int EnrollmentYear { get; set; }
    }
}
