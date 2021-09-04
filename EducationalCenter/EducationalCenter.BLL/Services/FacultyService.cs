using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalCenter.BLL.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FacultyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(FacultyDTO facultyCreationDto)
        {
            var faculty = _mapper.Map<Faculty>(facultyCreationDto);

            _unitOfWork.Faculties.Create(faculty);

            await _unitOfWork.Complete();
        }

        public async Task DeleteAsync(int id)
        {
            _unitOfWork.Faculties.Delete(id);
            await _unitOfWork.Complete();
        }

        public async Task<FacultyDTO> FindByIdAsync(int id)
        {
            var faculty = await _unitOfWork.Faculties.GetByIdAsync(id);

            return _mapper.Map<FacultyDTO>(faculty);
        }

        public async Task<IEnumerable<FacultyDTO>> GetAllAsync()
        {
            var faculties = await _unitOfWork.Faculties.GetAllAsync();

            return _mapper.Map<List<FacultyDTO>>(faculties);
        }

        public async Task UpdateAsync(FacultyDTO facultyUpdationDto)
        {
            var faculty = _mapper.Map<Faculty>(facultyUpdationDto);

            _unitOfWork.Faculties.Update(faculty);
            await _unitOfWork.Complete();
        }
    }
}
