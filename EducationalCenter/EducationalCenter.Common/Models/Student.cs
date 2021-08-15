namespace EducationalCenter.Common.Models
{
    public class Student : Person
    {
        public int EnrollmentYear { get; set; }
        public int GroupId { get; set; }
        public StudentGroup Group { get; set; }
    }
}
