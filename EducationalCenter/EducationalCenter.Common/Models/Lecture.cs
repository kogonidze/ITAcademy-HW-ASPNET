using System;

namespace EducationalCenter.Common.Models
{
    public class Lecture
    {
        public int Id { get; set; }

        public int? TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public int? CourseId { get; set; }

        public Course Course { get; set; }

        public int? StudentGroupId { get; set; }

        public StudentGroup StudentGroup { get; set; }

        public DateTime DateTime { get; set; }

        public string BuildingName { get; set; }

        public int AuditoriumNumber { get; set; }
    }
}
