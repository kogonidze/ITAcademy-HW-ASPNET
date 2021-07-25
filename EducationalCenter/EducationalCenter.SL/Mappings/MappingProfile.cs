using AutoMapper;
using EducationalCenter.Model;
using EducationalCenter.SL.DTO;

namespace EducationalCenter.SL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.FIO, opts => opts.MapFrom(src => src.FirstName + ' ' + src.LastName));
                
            CreateMap<StudentCreationDTO, Student>();

            CreateMap<StudentFullInfoDTO, Student>().ReverseMap();
        }
    }
}
