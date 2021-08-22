using System;
using EducationalCenter.Common.Dtos.StudentGroup;

namespace EducationalCenter.Common.Dtos.Student
{
    public class StudentDTO
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int GroupId { get; set; }

        public StudentGroupDTO Group { get; set; }
    }
}
