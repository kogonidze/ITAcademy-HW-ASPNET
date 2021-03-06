using System;

namespace EducationalCenter.Common.Dtos
{
    public class StudentDTO
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int? GroupId { get; set; }

        public StudentGroupDTO Group { get; set; }
    }
}
