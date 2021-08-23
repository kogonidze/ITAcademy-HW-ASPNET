using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Dtos.Teacher;
using EducationalCenter.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace EducationalCenter.Common.Dtos.StudentGroup
{
    public class StudentGroupDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Faculty Faculty { get; set; }

        public int TeacherId { get; set; }

        public TeacherDTO Teacher { get; set; }

        public int StartYear { get; set; }

        public int EndingYear { get; set; }
    }
}
