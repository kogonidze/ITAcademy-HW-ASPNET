using EducationalCenter.Common.Dtos.StudentGroup;
using System;

namespace EducationalCenter.Common.Dtos.Student
{
    public class StudentFullInfoDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string EMail { get; set; }

        public string PhoneNumber { get; set; }

        public int GroupId { get; set; }

        public StudentGroupDTO Group { get; set; }
    }
}
