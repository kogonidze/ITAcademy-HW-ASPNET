using System;
using EducationalCenter.Common.Enums;

namespace EducationalCenter.Common.Dtos.Student
{
    public class StudentCreationDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string EMail { get; set; }

        public string PhoneNumber { get; set; }

        public int GroupId { get; set; }
    }
}
