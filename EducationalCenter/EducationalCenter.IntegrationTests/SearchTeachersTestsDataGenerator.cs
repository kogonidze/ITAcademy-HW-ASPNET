using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Dtos.Api.Request;
using EducationalCenter.Common.Enums;
using EducationalCenter.Common.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace EducationalCenter.IntegrationTests
{
    public class SearchTeachersTestsDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {
                new GetFilteredTeachersRequest { FIO = "Ivanov", Page = 1, PageSize = 10},
                new List<TeacherDTO> {
                    new TeacherDTO {
                        Id = 1,
                        FIO = "Ivan Ivanov",
                        DateOfBirth = new DateTime(1987, 11, 04),
                        Formation = Formation.Master,
                        Category = Category.Second,
                        Department = new Department {Id = 1, Name = "Higher Algebra"},
                        DepartmentId = 1,
                        Experience = 5
                    }
                }
            },
            new object[]
            {
                new GetFilteredTeachersRequest { Experience = 8, Page = 1, PageSize = 10},
                new List<TeacherDTO> {
                    new TeacherDTO
                    {
                        Id = 3,
                        FIO = "Sidor Sidorov",
                        DateOfBirth = new DateTime(1959, 06, 21),
                        Category = Category.YoungSpecialist,
                        Department = new Department {Id = 1, Name = "Higher Algebra"},
                        DepartmentId = 1,
                        Formation = Formation.SeniorDoctorate,
                        Experience = 10,
                    },
                    new TeacherDTO
                    {
                        Id = 4,
                        FIO = "Vasili Vasiliev",
                        Category = Category.First,
                        DateOfBirth = new DateTime(1994, 12, 28),
                        Department = new Department {Id = 1, Name = "Higher Algebra"},
                        DepartmentId = 1,
                        Formation = Formation.SeniorDoctorate,
                        Experience = 14,
                    }

                }
            },
            new object[]
            {
                new GetFilteredTeachersRequest { Category = Category.First, Formation = Formation.PhD, Page = 1, PageSize = 10},
                new List<TeacherDTO>
                {
                    new TeacherDTO
                    {
                        Id = 2,
                        FIO = "Petr Petrov",
                        DateOfBirth = new DateTime(1991, 04, 14),
                        Category = Category.First,
                        Department = new Department {Id = 2, Name = "English"},
                        DepartmentId = 2,
                        Formation = Formation.PhD,
                        Experience = 4,
                    },
                    new TeacherDTO
                    {
                        Id = 4,
                        FIO = "Vasili Vasiliev",
                        Category = Category.First,
                        DateOfBirth = new DateTime(1994, 12, 28),
                        Department = new Department {Id = 1, Name = "Higher Algebra"},
                        DepartmentId = 1,
                        Formation = Formation.SeniorDoctorate,
                        Experience = 14,
                    }
                }
            }
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
