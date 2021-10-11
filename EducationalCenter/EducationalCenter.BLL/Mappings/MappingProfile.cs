using AutoMapper;
using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Dtos.Course;
using EducationalCenter.Common.Dtos.Student;
using EducationalCenter.Common.Dtos.Teacher;
using EducationalCenter.Common.Dtos.User;
using EducationalCenter.Common.Models;

namespace EducationalCenter.BLL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.FIO, opts => opts.MapFrom(src => src.FirstName + ' ' + src.LastName));

            CreateMap<StudentFullInfoDTO, Student>().ReverseMap();

            CreateMap<Teacher, TeacherDTO>()
                .ForMember(dest => dest.FIO, opts => opts.MapFrom(src => src.FirstName + ' ' + src.LastName));

            CreateMap<TeacherFullInfoDTO, Teacher>().ReverseMap();

            CreateMap<StudentGroup, StudentGroupDTO>();
            CreateMap<StudentGroupFullInfoDTO, StudentGroup>().ReverseMap();
            CreateMap<StudentGroupCreationDTO, StudentGroupFullInfoDTO>();

            CreateMap<Faculty, FacultyDTO>();
            CreateMap<FacultyCreationDTO, FacultyDTO>();

            CreateMap<Department, DepartmentDTO>();
            CreateMap<DepartmentCreationDTO, DepartmentDTO>();

            CreateMap<Course, CourseDTO>();

            CreateMap<UserRegistrationDto, ApplicationUser>()
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.EMail));
        }
    }
}
