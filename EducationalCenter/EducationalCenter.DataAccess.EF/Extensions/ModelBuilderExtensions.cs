using EducationalCenter.Common.Enums;
using EducationalCenter.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EducationalCenter.DataAccess.EF.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Department>().HasData(new Department { Id = 1, Name = "Philology" });
            builder.Entity<Department>().HasData(new Department { Id = 2, Name = "Algebras" });
            builder.Entity<Department>().HasData(new Department { Id = 3, Name = "Calculus" });

            builder.Entity<Faculty>().HasData(new Faculty { Id = 1, Name = "Applied Math" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 2, Name = "Information technologies" });

            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 1,
                FirstName = "Georg",
                LastName = "Cantor",
                DateOfBirth = new DateTime(1845, 03, 03),
                EMail = "georg.cantor@gmail.com",
                PhoneNumber = "1234567890",
                Category = Category.Highest,
                Formation = Formation.SeniorDoctorate,
                Experience = 10,
                DepartmentId = 3,
                Salary = 5000
            });

            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 2,
                FirstName = "Viktor",
                LastName = "Vagner",
                DateOfBirth = new DateTime(1908, 11, 4),
                EMail = "viktor.vagner@gmail.com",
                PhoneNumber = "2345678901",
                Category = Category.Highest,
                Formation = Formation.SeniorDoctorate,
                Experience = 15,
                DepartmentId = 2,
                Salary = 3500
            });

            builder.Entity<Course>().HasData(new Course
            {
                Id = 1,
                Title = "Calculus",
                Description = "The mathematical study of continuous change",
                HoursCount = 150,
                ControlForm = ControlForm.Exam
            });

            builder.Entity<Course>().HasData(new Course
            {
                Id = 2,
                Title = "Integral equations",
                Description = "The mathematical study of equations in which an unknown function appears under an integral sign",
                HoursCount = 100,
                ControlForm = ControlForm.Test
            });

            builder.Entity<Course>().HasData(new Course
            {
                Id = 3,
                Title = "Linear algebra",
                Description = "The branch of mathematics concerning linear equations",
                HoursCount = 200,
                ControlForm = ControlForm.Exam
            });
        }
    }
}