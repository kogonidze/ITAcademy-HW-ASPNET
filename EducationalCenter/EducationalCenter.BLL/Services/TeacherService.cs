using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos.Teacher;
using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalCenter.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(TeacherCreationDTO teacherCreationDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherCreationDto);

            _unitOfWork.Teachers.Create(teacher);
            await _unitOfWork.Complete();
        }

        public async Task DeleteAsync(int id)
        {
            _unitOfWork.Teachers.Delete(id);
            await _unitOfWork.Complete();
        }

        public async Task<TeacherFullInfoDTO> FindByIdAsync(int id)
        {
            var teacher = await _unitOfWork.Teachers.GetByIdAsync(id);

            return _mapper.Map<TeacherFullInfoDTO>(teacher);
        }

        public async Task<IEnumerable<TeacherDTO>> GetAllAsync()
        {
            var teachers = await _unitOfWork.Teachers.GetAllAsync();

            return _mapper.Map<List<TeacherDTO>>(teachers);
        }

        public async Task UpdateAsync(TeacherFullInfoDTO teacherUpdationDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherUpdationDto);

            _unitOfWork.Teachers.Update(teacher);
            await _unitOfWork.Complete();
        }
    }
}
