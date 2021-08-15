using EducationalCenter.Common.Enums;

namespace EducationalCenter.Common.Models
{
    public class StudentGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Faculty Faculty { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int StartYear { get; set; }
        public int EndingYear { get; set; }
    }
}
