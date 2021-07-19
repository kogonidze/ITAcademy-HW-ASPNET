using System;

namespace Decorator
{
    public class Employee: IEmployee
    {
        public string Name { get; set; }

        public DateTime HireDate { get; set; }

        public IEmployee Hire(string name, DateTime hireDate)
        {
            Name = name;
            HireDate = hireDate;
            return this;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
