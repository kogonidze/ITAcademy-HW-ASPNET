using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalCenter.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(DepartmentDTO departmentCreationDto)
        {
            var department = _mapper.Map<Department>(departmentCreationDto);

            _unitOfWork.Departments.Create(department);

            await _unitOfWork.Complete();
        }

        public async Task DeleteAsync(int id)
        {
            _unitOfWork.Departments.Delete(id);

            await _unitOfWork.Complete();
        }

        public async Task<DepartmentDTO> FindByIdAsync(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);

            return _mapper.Map<DepartmentDTO>(department);
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAllAsync()
        {
            var departments = await _unitOfWork.Departments.GetAllAsync();

            return _mapper.Map<List<DepartmentDTO>>(departments);
        }

        public async Task UpdateAsync(DepartmentDTO departmentUpdationDto)
        {
            var department = _mapper.Map<Department>(departmentUpdationDto);

            _unitOfWork.Departments.Update(department);
            await _unitOfWork.Complete();
        }
    }
}
