using System;
using EducationalCenter.Common.Enums;

namespace EducationalCenter.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Faculty Faculty { get; set; }
        public int EnrollmentYear { get; set; }
    }
}
