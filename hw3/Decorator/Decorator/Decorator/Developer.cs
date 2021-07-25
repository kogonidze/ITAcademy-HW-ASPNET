using System;

namespace Decorator.Decorator
{
    public class Developer: EmployeeDecorator
    {
        public Developer(IEmployee employee) : base(employee)
        {
        }

        public void PerformTask()
        {
            Console.WriteLine($"Developer {this.Employee.GetName()} is performing current task now!");
        }

        public void DrinkTea()
        {
            Console.WriteLine($"Developer {this.Employee.GetName()} is drinking tea now!");
        }
    }
}
