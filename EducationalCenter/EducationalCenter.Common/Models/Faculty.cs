using System.Collections.Generic;

namespace EducationalCenter.Common.Models
{
    public class Faculty
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Department> Departments { get; set; }
    }
}
