using System.Collections.Generic;
using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos.Student;
using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;

namespace EducationalCenter.SL
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository repository, IMapper mapper)
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
