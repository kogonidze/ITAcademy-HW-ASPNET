using System;

namespace Decorator
{
    public interface IEmployee
    {
        IEmployee Hire(string name, DateTime hireDate);

        string GetName();
    }
}
