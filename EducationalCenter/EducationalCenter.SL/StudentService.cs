using System.Collections.Generic;
using AutoMapper;
using EducationalCenter.IBL;
using EducationalCenter.ISL;
using EducationalCenter.Model;
using EducationalCenter.SL.DTO;

namespace EducationalCenter.SL
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _repository;
        private readonly IMapper _mapper;

        public StudentService(IGenericRepository<Student> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<StudentDTO> GetAll()
        {
            var students = _repository.GetAll();

            return _mapper.Map<List<StudentDTO>>(students);
        }
    }
}
