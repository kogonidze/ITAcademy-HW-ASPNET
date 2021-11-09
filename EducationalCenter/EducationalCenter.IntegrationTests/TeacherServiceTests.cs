using AutoMapper;
using EducationalCenter.BLL.Mappings;
using EducationalCenter.BLL.Services;
using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Dtos.Api.Request;
using EducationalCenter.Common.Enums;
using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace EducationalCenter.IntegrationTests
{
    public class TeacherServiceTests
    {
        private IMapper _mapper;
        private List<Teacher> _teachers;
        private Mock<ITeacherRepository> _teacherRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private TeacherService _teacherService;

        public TeacherServiceTests()
        {
            if (_mapper == null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.AddProfile<MappingProfile>();
                });

                _mapper = new Mapper(config);
            }

            _teachers = GetTeachers();
            _teacherRepositoryMock = new Mock<ITeacherRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _unitOfWorkMock.Setup(_ => _.Teachers).Returns(_teacherRepositoryMock.Object);

            _teacherService = new TeacherService(_unitOfWorkMock.Object, _mapper);
        }

        [Fact]
        public async Task Should_TeacherService_GetAll_WorksCorrect()
        {
            _teacherRepositoryMock.Setup(_ => _.GetAllAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(_teachers);

            var result = (List<TeacherDTO>)await _teacherService.GetAllAsync();

            Assert.Equal(4, result.Count);
            Assert.Equal("Ivan Ivanov", result[0].FIO);
            Assert.Equal("Petr Petrov", result[1].FIO);
            Assert.Equal("Sidor Sidorov", result[2].FIO);
            Assert.Equal("Vasili Vasiliev", result[3].FIO);
        }

        [Theory]
        [ClassData(typeof(SearchTeachersTestsDataGenerator))]
        public async Task Should_TeacherService_GetByFilter_WorksCorrect(GetFilteredTeachersRequest request, List<TeacherDTO> expectedResult)
        {
            Func<Teacher, bool> predicate = (_ => (
                   (request.FIO == null || (_.FirstName + ' ' + _.LastName).Contains(request.FIO)) &&
                   (request.Category == null || (int)_.Category >= (int)request.Category) &&
                   (request.Formation == null || (int)_.Formation >= (int)request.Formation) &&
                   (request.Experience == null || _.Experience >= request.Experience)));

            _teacherRepositoryMock.Setup(_ => _.GetByFilterAsync(It.IsAny<Expression<Func<Teacher, bool>>>(), 
                                                                    It.IsAny<int>(), 
                                                                    It.IsAny<int>()))
                                                .ReturnsAsync(_teachers.Where(predicate).ToList());

            var result = (List<TeacherDTO>)await _teacherService.GetByFilterAsync(request);

            Assert.Equal(expectedResult, result);
        }


        private List<Teacher> GetTeachers()
        {
            return new List<Teacher>()
            {
                new Teacher
                {
                    Id = 1,
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    DateOfBirth = new DateTime(1987, 11, 04),
                    Category = Category.Second,
                    Department = new Department {Id = 1, Name = "Higher Algebra"},
                    DepartmentId = 1,
                    Formation = Formation.Master,
                    EMail = "ivan.ivanov@yandex.by",
                    Experience = 5,
                    PhoneNumber = "375291234567",
                    Salary = 3000
                },
                new Teacher
                {
                    Id = 2,
                    FirstName = "Petr",
                    LastName = "Petrov",
                    DateOfBirth = new DateTime(1991, 04, 14),
                    Category = Category.First,
                    Department = new Department {Id = 2, Name = "English"},
                    DepartmentId = 2,
                    Formation = Formation.PhD,
                    EMail = "petr.petrov@gmail.com",
                    Experience = 4,
                    PhoneNumber = "375292345678",
                    Salary = 4000
                },
                new Teacher
                {
                    Id = 3,
                    FirstName = "Sidor",
                    LastName = "Sidorov",
                    Category = Category.YoungSpecialist,
                    DateOfBirth = new DateTime(1959, 06, 21),
                    Department = new Department {Id = 1, Name = "Higher Algebra"},
                    DepartmentId = 1,
                    Formation = Formation.SeniorDoctorate,
                    EMail = "sidor.sidorov@gmail.com",
                    Experience = 10,
                    PhoneNumber = "375293456789",
                    Salary = 5000
                },
                new Teacher
                {
                    Id = 4,
                    FirstName = "Vasili",
                    LastName = "Vasiliev",
                    Category = Category.First,
                    DateOfBirth = new DateTime(1994, 12, 28),
                    Department = new Department {Id = 1, Name = "Higher Algebra"},
                    DepartmentId = 1,
                    Formation = Formation.SeniorDoctorate,
                    EMail = "vasili.vasiliev@mail.ru",
                    Experience = 14,
                    PhoneNumber = "375294567890",
                    Salary = 5000
                }
            };
        }
    }
}
