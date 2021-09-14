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
            builder.SeedFaculties();

            builder.SeedDepartments();

            builder.SeedTeachers();

            builder.SeedStudentGroups();

            builder.SeedCourses();

            builder.SeedStudents();
        }

        private static void SeedFaculties(this ModelBuilder builder)
        {
            builder.Entity<Faculty>().HasData(new Faculty { Id = 1, Name = "Mechanics and Mathematics" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 2, Name = "Computational Mathematics and Cybernetics" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 3, Name = "Physics" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 4, Name = "Chemistry" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 5, Name = "Materials Science" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 6, Name = "Biology" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 7, Name = "Bioengineering and Bioinformatics" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 8, Name = "Soil Science" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 9, Name = "Geology" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 10, Name = "Geography" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 11, Name = "Fundamental Medicine" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 12, Name = "Biotechnology" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 13, Name = "Space Research" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 14, Name = "History" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 15, Name = "Philology" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 16, Name = "Philosophy" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 17, Name = "Economics" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 18, Name = "Law" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 19, Name = "Journalism" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 20, Name = "Psychology" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 21, Name = "Sociology" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 22, Name = "Foreign Languages ​​and Regional Studies" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 23, Name = "Public Administration" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 24, Name = "World Politics" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 25, Name = "Arts" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 26, Name = "Global Processes" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 27, Name = "Pedagogical Education" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 28, Name = "Political Science" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 29, Name = "Business" });
            builder.Entity<Faculty>().HasData(new Faculty { Id = 30, Name = "Television" });
        }

        private static void SeedDepartments(this ModelBuilder builder)
        {
            builder.Entity<Department>().HasData(new Department { Id = 1, Name = "English", FacultyId = null });
            builder.Entity<Department>().HasData(new Department { Id = 2, Name = "Higher Algebra", FacultyId = 1 });
            builder.Entity<Department>().HasData(new Department { Id = 3, Name = "Mathematical Analysis", FacultyId = 1 });
            builder.Entity<Department>().HasData(new Department { Id = 4, Name = "Geometry and Topology", FacultyId = 1 });
            builder.Entity<Department>().HasData(new Department { Id = 5, Name = "Computational Mathematics", FacultyId = 1 });
            builder.Entity<Department>().HasData(new Department { Id = 6, Name = "Discrete Mathematics", FacultyId = 1 });
            builder.Entity<Department>().HasData(new Department { Id = 7, Name = "Differential Geometry and Its Applications", FacultyId = 1 });
            builder.Entity<Department>().HasData(new Department { Id = 8, Name = "Differential Equations", FacultyId = 1 });
            builder.Entity<Department>().HasData(new Department { Id = 9, Name = "Mathematical Logic and Theory of Algorithms", FacultyId = 1 });
            builder.Entity<Department>().HasData(new Department { Id = 10, Name = "General topology and geometry", FacultyId = 1 });
            builder.Entity<Department>().HasData(new Department { Id = 11, Name = "General management challenges", FacultyId = 1 });
            builder.Entity<Department>().HasData(new Department { Id = 12, Name = "Theoretical informatics", FacultyId = 1 });
            builder.Entity<Department>().HasData(new Department { Id = 13, Name = "Probability Theory", FacultyId = 1 });
            builder.Entity<Department>().HasData(new Department { Id = 14, Name = "Theory of Dynamical Systems", FacultyId = 1 });
            builder.Entity<Department>().HasData(new Department { Id = 15, Name = "Number theory", FacultyId = 1 });
            builder.Entity<Department>().HasData(new Department { Id = 16, Name = "Mathematical Statistics and Stochastic Processes", FacultyId = 1 });
            builder.Entity<Department>().HasData(new Department { Id = 17, Name = "Theory of Functions and Functional Analysis", FacultyId = 1 });
        }
   
        private static void SeedTeachers(this ModelBuilder builder)
        {
            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 1,
                FirstName = "Aleksey",
                LastName = "Suhorukov",
                DateOfBirth = new DateTime(1983, 06, 7),
                EMail = "aleksey.suhorukov@gmail.com",
                PhoneNumber = "80291700544",
                Category = Category.Second,
                Formation = Formation.Master,
                Experience = 4,
                DepartmentId = 1,
                Salary = 1500
            });

            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 2,
                FirstName = "Viktor",
                LastName = "Vagner",
                DateOfBirth = new DateTime(1908, 11, 4),
                EMail = "viktor.vagner@gmail.com",
                PhoneNumber = "80338690014",
                Category = Category.Highest,
                Formation = Formation.SeniorDoctorate,
                Experience = 15,
                DepartmentId = 2,
                Salary = 3500
            });

            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 3,
                FirstName = "Georg",
                LastName = "Cantor",
                DateOfBirth = new DateTime(1845, 03, 03),
                EMail = "georg.cantor@gmail.com",
                PhoneNumber = "80258438118",
                Category = Category.Highest,
                Formation = Formation.SeniorDoctorate,
                Experience = 10,
                DepartmentId = 3,
                Salary = 5000
            });

            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 4,
                FirstName = "Nikolay",
                LastName = "Lobachevskiy",
                DateOfBirth = new DateTime(1792, 12, 01),
                EMail = "nikolay.lobachevskiy@gmail.com",
                PhoneNumber = "80297304512",
                Category = Category.Highest,
                Formation = Formation.PhD,
                Experience = 13,
                DepartmentId = 4,
                Salary = 4360
            });

            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 5,
                FirstName = "Yuriy",
                LastName = "Vasilevskiy",
                DateOfBirth = new DateTime(1967, 03, 11),
                EMail = "yuriy.vasilevskiy@gmail.com",
                PhoneNumber = "80335936308",
                Category = Category.Highest,
                Formation = Formation.SeniorDoctorate,
                Experience = 14,
                DepartmentId = 5,
                Salary = 5690
            });

            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 6,
                FirstName = "Sergey",
                LastName = "Yablonskiy",
                DateOfBirth = new DateTime(1924, 12, 06),
                EMail = "sergey.yablonskiy@gmail.com",
                PhoneNumber = "80298602366",
                Category = Category.Highest,
                Formation = Formation.SeniorDoctorate,
                Experience = 21,
                DepartmentId = 6,
                Salary = 8200
            });

            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 7,
                FirstName = "Anatoliy",
                LastName = "Fomenko",
                DateOfBirth = new DateTime(1976, 08, 12),
                EMail = "anatoliy.fomenko@gmail.com",
                PhoneNumber = "80298989783",
                Category = Category.First,
                Formation = Formation.Master,
                Experience = 6,
                DepartmentId = 7,
                Salary = 3500
            });

            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 8,
                FirstName = "Katerina",
                LastName = "Lyutova",
                DateOfBirth = new DateTime(1988, 07, 05),
                EMail = "katenka489@mail.ru",
                PhoneNumber = "80294041777",
                Category = Category.First,
                Formation = Formation.Master,
                Experience = 5,
                DepartmentId = 8,
                Salary = 2700
            });

            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 9,
                FirstName = "Varvara",
                LastName = "Pivovarova",
                DateOfBirth = new DateTime(1961, 06, 26),
                EMail = "varvara1961@ya.ru",
                PhoneNumber = "80297213791",
                Category = Category.Highest,
                Formation = Formation.PhD,
                Experience = 25,
                DepartmentId = 9,
                Salary = 7500
            });


            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 10,
                FirstName = "Anton",
                LastName = "Mazaev",
                DateOfBirth = new DateTime(1975, 09, 21),
                EMail = "anton1314@mail.ru",
                PhoneNumber = "80294097837",
                Category = Category.First,
                Formation = Formation.Master,
                Experience = 12,
                DepartmentId = 10,
                Salary = 5100
            });


            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 11,
                FirstName = "Anton",
                LastName = "Kasatkin",
                DateOfBirth = new DateTime(1970, 09, 14),
                EMail = "anton14091970@gmail.com",
                PhoneNumber = "80292323673",
                Category = Category.First,
                Formation = Formation.Master,
                Experience = 15,
                DepartmentId = 11,
                Salary = 5300
            });

            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 12,
                FirstName = "Lyudmila",
                LastName = "Yudashkina",
                DateOfBirth = new DateTime(1997, 12, 05),
                EMail = "lyudmila.yudashkina@yandex.ru",
                PhoneNumber = "80292512777",
                Category = Category.YoungSpecialist,
                Formation = Formation.Bachelor,
                Experience = 1,
                DepartmentId = 12,
                Salary = 1800
            });

            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 13,
                FirstName = "Valentin",
                LastName = "Yurlov",
                DateOfBirth = new DateTime(1963, 05, 01),
                EMail = "valentin2091@mail.ru",
                PhoneNumber = "80291439863",
                Category = Category.First,
                Formation = Formation.Master,
                Experience = 23,
                DepartmentId = 13,
                Salary = 1800
            });

            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 14,
                FirstName = "Nikolay",
                LastName = "Kuraev",
                DateOfBirth = new DateTime(1996, 07, 16),
                EMail = "nikolay16071996@mail.ru",
                PhoneNumber = "80299709082",
                Category = Category.YoungSpecialist,
                Formation = Formation.Master,
                Experience = 1,
                DepartmentId = 14,
                Salary = 1950
            });

            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 15,
                FirstName = "Fedot",
                LastName = "Pershikov",
                DateOfBirth = new DateTime(1984, 09, 12),
                EMail = "fedot.parshikov@ya.ru",
                PhoneNumber = "80298608842",
                Category = Category.Second,
                Formation = Formation.Master,
                Experience = 4,
                DepartmentId = 15,
                Salary = 2300
            });

            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 16,
                FirstName = "Fedot",
                LastName = "Pershikov",
                DateOfBirth = new DateTime(1984, 09, 12),
                EMail = "fedot.parshikov@ya.ru",
                PhoneNumber = "80298608842",
                Category = Category.Second,
                Formation = Formation.Master,
                Experience = 4,
                DepartmentId = 16,
                Salary = 2300
            });

            builder.Entity<Teacher>().HasData(new Teacher
            {
                Id = 17,
                FirstName = "Fedot",
                LastName = "Pershikov",
                DateOfBirth = new DateTime(1984, 09, 12),
                EMail = "fedot.parshikov@ya.ru",
                PhoneNumber = "80298608842",
                Category = Category.Second,
                Formation = Formation.Master,
                Experience = 4,
                DepartmentId = 17,
                Salary = 2300
            });
        }

        private static void SeedStudentGroups(this ModelBuilder builder)
        {
            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 1,
                Title = "21-1-1",
                FacultyId = 1,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 2,
                Title = "21-2-1",
                FacultyId = 2,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 3,
                Title = "21-3-1",
                FacultyId = 3,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 4,
                Title = "21-4-1",
                FacultyId = 4,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 5,
                Title = "21-5-1",
                FacultyId = 5,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 6,
                Title = "21-6-1",
                FacultyId = 6,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 7,
                Title = "21-7-1",
                FacultyId = 7,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 8,
                Title = "21-8-1",
                FacultyId = 8,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 9,
                Title = "21-9-1",
                FacultyId = 9,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 10,
                Title = "21-10-1",
                FacultyId = 10,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 11,
                Title = "21-11-1",
                FacultyId = 11,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 12,
                Title = "21-12-1",
                FacultyId = 12,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 13,
                Title = "21-13-1",
                FacultyId = 13,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 14,
                Title = "21-14-1",
                FacultyId = 14,
                StartYear = 2021,
                EndingYear = 2026
            });


            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 15,
                Title = "21-15-1",
                FacultyId = 15,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 16,
                Title = "21-16-1",
                FacultyId = 16,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 17,
                Title = "21-17-1",
                FacultyId = 17,
                StartYear = 2021,
                EndingYear = 2026
            });


            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 18,
                Title = "21-18-1",
                FacultyId = 18,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 19,
                Title = "21-19-1",
                FacultyId = 19,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 20,
                Title = "21-20-1",
                FacultyId = 20,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 21,
                Title = "21-21-1",
                FacultyId = 21,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 22,
                Title = "21-22-1",
                FacultyId = 22,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 23,
                Title = "21-23-1",
                FacultyId = 23,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 24,
                Title = "21-24-1",
                FacultyId = 24,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 25,
                Title = "21-25-1",
                FacultyId = 25,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 26,
                Title = "21-26-1",
                FacultyId = 26,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 27,
                Title = "21-27-1",
                FacultyId = 27,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 28,
                Title = "21-28-1",
                FacultyId = 28,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 29,
                Title = "21-29-1",
                FacultyId = 29,
                StartYear = 2021,
                EndingYear = 2026
            });

            builder.Entity<StudentGroup>().HasData(new StudentGroup
            {
                Id = 30,
                Title = "21-30-1",
                FacultyId = 30,
                StartYear = 2021,
                EndingYear = 2026
            });
        }

        private static void SeedCourses(this ModelBuilder builder)
        {
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

            builder.Entity<Course>().HasData(new Course
            {
                Id = 4,
                Title = "The history of Belarus",
                Description = "The study about the history of Belarus in 20th century",
                HoursCount = 100,
                ControlForm = ControlForm.Test
            });

            builder.Entity<Course>().HasData(new Course
            {
                Id = 5,
                Title = "Philosophy",
                Description = "The study about basics of the philosophy",
                HoursCount = 100,
                ControlForm = ControlForm.Test
            });

            builder.Entity<Course>().HasData(new Course
            {
                Id = 6,
                Title = "English",
                Description = "English lessons",
                HoursCount = 400,
                ControlForm = ControlForm.Exam
            });

            builder.Entity<Course>().HasData(new Course
            {
                Id = 7,
                Title = "Geometry",
                Description = "The branch of mathematics concerning with properties of space that are related with distance, shape, size, and relative position of figures.",
                HoursCount = 200,
                ControlForm = ControlForm.Exam
            });

            builder.Entity<Course>().HasData(new Course
            {
                Id = 8,
                Title = "Discrete Mathematics",
                Description = "The study of mathematical structures that are fundamentally discrete rather than continuous.",
                HoursCount = 250,
                ControlForm = ControlForm.Exam
            });

            builder.Entity<Course>().HasData(new Course
            {
                Id = 9,
                Title = "Mathematical Logic",
                Description = "The study of logic within mathematics",
                HoursCount = 200,
                ControlForm = ControlForm.Exam
            });

            builder.Entity<Course>().HasData(new Course
            {
                Id = 10,
                Title = "Theory Of Algorithms",
                Description = "The branch of mathematics dealing with the general properties of algorithms",
                HoursCount = 100,
                ControlForm = ControlForm.Test
            });

            builder.Entity<Course>().HasData(new Course
            {
                Id = 11,
                Title = "Probability theory",
                Description = "The branch of mathematics concerned with probability.",
                HoursCount = 240,
                ControlForm = ControlForm.Exam
            });

            builder.Entity<Course>().HasData(new Course
            {
                Id = 12,
                Title = "Mathematical statistics",
                Description = "The application of probability theory, a branch of mathematics, to statistics, as opposed to techniques for collecting statistical data.",
                HoursCount = 150,
                ControlForm = ControlForm.Test
            });

            builder.Entity<Course>().HasData(new Course
            {
                Id = 13,
                Title = "Physics",
                Description = "The natural science that studies matter, its motion and behavior through space and time, and the related entities of energy and force.",
                HoursCount = 300,
                ControlForm = ControlForm.Exam
            });
        }

        private static void SeedStudents(this ModelBuilder builder)
        {

            builder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                FirstName = "Mariya",
                LastName = "Akimova",
                DateOfBirth = new DateTime(2003, 05, 28),
                EMail = "masha4221@ya.ru",
                PhoneNumber = "80299383772",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 2,
                FirstName = "Maxim",
                LastName = "Alekseev",
                DateOfBirth = new DateTime(2002, 03, 25),
                EMail = "maxim.alekseev2002@gmail.com",
                PhoneNumber = "80292923022",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 3,
                FirstName = "Aleksey",
                LastName = "Alekseev",
                DateOfBirth = new DateTime(2002, 06, 25),
                EMail = "aleksey.alekseev2002@gmail.com",
                PhoneNumber = "80290876946",
                GroupId = 1
            });


            builder.Entity<Student>().HasData(new Student
            {
                Id = 4,
                FirstName = "Viktor",
                LastName = "Arhipov",
                DateOfBirth = new DateTime(2001, 04, 04),
                EMail = "viktor.arhipov@gmail.com",
                PhoneNumber = "80290881237",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 5,
                FirstName = "Viktor",
                LastName = "Baranov",
                DateOfBirth = new DateTime(2002, 02, 21),
                EMail = "viktor.baranov@gmail.com",
                PhoneNumber = "80297555386",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 6,
                FirstName = "Vasili",
                LastName = "Belousov",
                DateOfBirth = new DateTime(2001, 08, 11),
                EMail = "vasili.belousov@gmail.com",
                PhoneNumber = "80298898114",
                GroupId = 1
            });


            builder.Entity<Student>().HasData(new Student
            {
                Id = 7,
                FirstName = "Sofiya",
                LastName = "Belousova",
                DateOfBirth = new DateTime(2001, 07, 11),
                EMail = "sofiya.belousova@gmail.com",
                PhoneNumber = "80290179645",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 8,
                FirstName = "Mikhail",
                LastName = "Borisov",
                DateOfBirth = new DateTime(2002, 10, 05),
                EMail = "mikhail.borisov@mail.ru",
                PhoneNumber = "80292485857",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 9,
                FirstName = "Mark",
                LastName = "Vasiliev",
                DateOfBirth = new DateTime(2001, 03, 20),
                EMail = "mark.vasiliev@mail.ru",
                PhoneNumber = "80291314170",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 10,
                FirstName = "Valeriya",
                LastName = "Vasilieva",
                DateOfBirth = new DateTime(2002, 11, 04),
                EMail = "valeriya.vasilieva@mail.ru",
                PhoneNumber = "80295986128",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 11,
                FirstName = "Vitaliy",
                LastName = "Vinokurov",
                DateOfBirth = new DateTime(2003, 08, 01),
                EMail = "valeriya.vasilieva@mail.ru",
                PhoneNumber = "80292959451",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 12,
                FirstName = "Alexander",
                LastName = "Vlasov",
                DateOfBirth = new DateTime(2003, 06, 17),
                EMail = "alexander.vlasov@gmail.com",
                PhoneNumber = "80297387311",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 13,
                FirstName = "Arina",
                LastName = "Volkova",
                DateOfBirth = new DateTime(2003, 02, 28),
                EMail = "arina.volkova@gmail.com",
                PhoneNumber = "80295752575",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 14,
                FirstName = "Taisia",
                LastName = "Voloshina",
                DateOfBirth = new DateTime(2002, 08, 12),
                EMail = "taisia.voloshina@gmail.com",
                PhoneNumber = "80295752575",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 15,
                FirstName = "Oleg",
                LastName = "Prokopovich",
                DateOfBirth = new DateTime(2002, 08, 12),
                EMail = "oleg.prokopovich@gmail.com",
                PhoneNumber = "80293840939",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 16,
                FirstName = "Eva",
                LastName = "Galkina",
                DateOfBirth = new DateTime(2003, 04, 01),
                EMail = "eva.galkina@gmail.com",
                PhoneNumber = "80292417030",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 17,
                FirstName = "Olga",
                LastName = "Gerasimova",
                DateOfBirth = new DateTime(2004, 01, 20),
                EMail = "olga.gerasimova@gmail.com",
                PhoneNumber = "80296959163",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 18,
                FirstName = "Vladimir",
                LastName = "Ivanov",
                DateOfBirth = new DateTime(2004, 02, 22),
                EMail = "vladimir.ivanov@gmail.com",
                PhoneNumber = "80293899049",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 19,
                FirstName = "Egor",
                LastName = "Kirillov",
                DateOfBirth = new DateTime(2003, 12, 21),
                EMail = "egor.kirillov@gmail.com",
                PhoneNumber = "80293342034",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 20,
                FirstName = "Anna",
                LastName = "Kruglova",
                DateOfBirth = new DateTime(2002, 05, 13),
                EMail = "anna.kruglova@gmail.com",
                PhoneNumber = "80298668976",
                GroupId = 1
            });

            builder.Entity<Student>().HasData(new Student
            {
                Id = 21,
                FirstName = "Veronika",
                LastName = "Lebedeva",
                DateOfBirth = new DateTime(2003, 05, 12),
                EMail = "veronika.lebedeva@mail.ru",
                PhoneNumber = "80297158895",
                GroupId = 1
            });
        }
    }
}