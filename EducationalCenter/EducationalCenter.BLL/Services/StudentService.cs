using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos.Student;
using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;

namespace EducationalCenter.SL
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            var students = await _unitOfWork.Students.GetAllAsync();

            return _mapper.Map<List<StudentDTO>>(students);
        }

        public async Task CreateAsync(StudentCreationDTO studentCreationDto)
        {
            var student = _mapper.Map<Student>(studentCreationDto);

            _unitOfWork.Students.Create(student);
            await _unitOfWork.Complete();
        }

        public async Task<StudentFullInfoDTO> FindByIdAsync(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);

            return _mapper.Map<StudentFullInfoDTO>(student);
        }

        public async Task UpdateAsync(StudentFullInfoDTO studentUpdationDto)
        {
            var student = _mapper.Map<Student>(studentUpdationDto);

            _unitOfWork.Students.Update(student);
            await _unitOfWork.Complete();
        }

        public async Task DeleteAsync(int id)
        {
            _unitOfWork.Students.Delete(id);
            await _unitOfWork.Complete();
        }
    }
}
