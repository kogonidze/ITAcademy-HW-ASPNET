using System;

namespace EducationalCenter.Common.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string EMail { get; set; }

        public string PhoneNumber { get; set; }
    }
}
