using System;

namespace Decorator.Decorator
{
    public class TeamLead: EmployeeDecorator
    {
        public TeamLead(IEmployee employee) : base(employee)
        {
        }

        public void CreateTask()
        {
            Console.WriteLine($"TeamLead {this.Employee.GetName()} created new task!");
        }

        public void DoCodeReview()
        {
            Console.WriteLine($"TeamLead {this.Employee.GetName()} is doing code review now!");
        }
    }
}
