using AutoMapper;
using EducationalCenter.Common.Dtos.Student;
using EducationalCenter.Common.Dtos.Teacher;
using EducationalCenter.Common.Models;

namespace EducationalCenter.BLL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.FIO, opts => opts.MapFrom(src => src.FirstName + ' ' + src.LastName));

            CreateMap<StudentCreationDTO, Student>();

            CreateMap<StudentFullInfoDTO, Student>().ReverseMap();

            CreateMap<Teacher, TeacherDTO>()
                .ForMember(dest => dest.FIO, opts => opts.MapFrom(src => src.FirstName + ' ' + src.LastName));

            CreateMap<TeacherCreationDTO, Teacher>();

            CreateMap<TeacherFullInfoDTO, Teacher>().ReverseMap();
        }
    }
}
