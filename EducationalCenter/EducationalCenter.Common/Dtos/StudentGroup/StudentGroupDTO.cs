using EducationalCenter.Common.Models;

namespace EducationalCenter.Common.Dtos
{
    public class StudentGroupDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? FacultyId { get; set; }

        public Faculty Faculty { get; set; }

        public int StartYear { get; set; }

        public int EndingYear { get; set; }
    }
}
