using EducationalCenter.Common.Enums;
using System;

namespace EducationalCenter.Common.Dtos.Teacher
{
    public class TeacherCreationDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string EMail { get; set; }

        public string PhoneNumber { get; set; }

        public int Experience { get; set; }

        public Category Category { get; set; }

        public Formation Formation { get; set; }

        public int Salary { get; set; }
    }
}
