using System;
using Decorator.Decorator;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployee employee1 = new Employee();
            employee1.Hire("Petr", DateTime.Now);
            Developer developer = new Developer(employee1);

            developer.PerformTask();
            developer.DrinkTea();

            IEmployee employee2 = new Employee();
            TeamLead teamLead = new TeamLead(employee2);
            teamLead.Hire("Oleg", DateTime.Now);

            teamLead.CreateTask();
            teamLead.DoCodeReview();

            Console.ReadKey();
        }
    }
}
