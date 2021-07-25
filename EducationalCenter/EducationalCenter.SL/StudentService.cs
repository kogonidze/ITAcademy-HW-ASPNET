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

        public void Create(StudentCreationDTO studentCreationDto)
        {
            var student = _mapper.Map<Student>(studentCreationDto);

            _repository.Create(student);
        }

        public StudentFullInfoDTO FindById(int id)
        {
            var student = _repository.GetById(id);

            return _mapper.Map<StudentFullInfoDTO>(student);
        }

        public void Update(StudentFullInfoDTO studentUpdationDto)
        {
            var student = _mapper.Map<Student>(studentUpdationDto);

            _repository.Update(student);
        }

        public void Delete(StudentFullInfoDTO studentDeletionDto)
        {
            var student = _mapper.Map<Student>(studentDeletionDto);

            _repository.Delete(student);
        }
    }
}
