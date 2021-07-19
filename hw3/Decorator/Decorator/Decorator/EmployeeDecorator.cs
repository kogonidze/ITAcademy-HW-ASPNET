using System;

namespace Decorator.Decorator
{
    public abstract class EmployeeDecorator: IEmployee
    {
        protected IEmployee Employee;

        protected EmployeeDecorator(IEmployee employee)
        {
            Employee = employee;
        }

        public IEmployee Hire(string name, DateTime hireDate)
        {
            return Employee.Hire(name, hireDate);
        }

        public string GetName()
        {
            return Employee.GetName();
        }
    }
}
