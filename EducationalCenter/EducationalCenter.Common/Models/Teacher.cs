using EducationalCenter.Common.Enums;

namespace EducationalCenter.Common.Models
{
    public class Teacher : Person
    {
        public int? DepartmentId { get; set; }

        public Department Department { get; set; }

        public int Experience { get; set; }

        public Category Category { get; set; }

        public Formation Formation { get; set; }

        public int Salary { get; set; }
    }
}
