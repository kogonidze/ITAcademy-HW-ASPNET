using EducationalCenter.Common.Enums;

namespace EducationalCenter.Common.Dtos.Course
{
    public class CourseFullInfoDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int HoursCount { get; set; }

        public string ControlForm { get; set; }
    }
}
