using EducationalCenter.Common.Enums;

namespace EducationalCenter.Common.Dtos.StudentGroup
{
    public class StudentGroupCreationDTO
    {
        public string Title { get; set; }

        public Faculty Faculty { get; set; }

        public int TeacherId { get; set; }

        public int StartYear { get; set; }

        public int EndingYear { get; set; }
    }
}
