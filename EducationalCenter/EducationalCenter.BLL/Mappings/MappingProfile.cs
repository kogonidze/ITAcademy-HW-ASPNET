using AutoMapper;
using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Dtos.Log;
using EducationalCenter.Common.Dtos.User;
using EducationalCenter.Common.Models;
using System;

namespace EducationalCenter.BLL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.FIO, opts => opts.MapFrom(src => src.FirstName + ' ' + src.LastName));

            CreateMap<StudentFullInfoDTO, Student>().ReverseMap();
            CreateMap<StudentCreationDTO, StudentFullInfoDTO>();

            CreateMap<Teacher, TeacherDTO>()
                .ForMember(dest => dest.FIO, opts => opts.MapFrom(src => src.FirstName + ' ' + src.LastName));

            CreateMap<TeacherFullInfoDTO, Teacher>().ReverseMap();
            CreateMap<TeacherCreationDTO, TeacherFullInfoDTO>();

            CreateMap<StudentGroup, StudentGroupDTO>();
            CreateMap<StudentGroupFullInfoDTO, StudentGroup>().ReverseMap();
            CreateMap<StudentGroupCreationDTO, StudentGroupFullInfoDTO>();

            CreateMap<Faculty, FacultyDTO>();
            CreateMap<FacultyCreationDTO, FacultyDTO>();

            CreateMap<Department, DepartmentDTO>();
            CreateMap<DepartmentCreationDTO, DepartmentDTO>();

            CreateMap<Course, CourseDTO>();
            CreateMap<CourseCreationDTO, CourseFullInfoDTO>();

            CreateMap<UserRegistrationDto, ApplicationUser>()
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.EMail));

            CreateMap<Log, LogDto>()
                .ForMember(dest => dest.LogDate, opts => opts.MapFrom(src => src.TimeStamp.DateTime));
        }
    }
}
