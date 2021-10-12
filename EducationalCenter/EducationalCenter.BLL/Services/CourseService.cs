using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalCenter.BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(CourseFullInfoDTO courseCreationDto)
        {
            var course = _mapper.Map<Course>(courseCreationDto);

            _unitOfWork.Courses.Create(course);

            await _unitOfWork.Complete();
        }

        public async Task DeleteAsync(int id)
        {
            _unitOfWork.Courses.Delete(id);

            await _unitOfWork.Complete();
        }

        public async Task<CourseFullInfoDTO> FindByIdAsync(int id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);

            return _mapper.Map<CourseFullInfoDTO>(course);
        }

        public async Task<IEnumerable<CourseDTO>> GetAllAsync()
        {
            var courses = await _unitOfWork.Courses.GetAllAsync();

            return _mapper.Map<List<CourseDTO>>(courses);
        }

        public async Task UpdateAsync(CourseFullInfoDTO courseUpdationDto)
        {
            var course = _mapper.Map<Course>(courseUpdationDto);

            _unitOfWork.Courses.Update(course);
            await _unitOfWork.Complete();
        }
    }
}
