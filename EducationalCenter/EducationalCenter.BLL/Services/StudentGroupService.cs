using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos.StudentGroup;
using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalCenter.BLL.Services
{
    public class StudentGroupService : IStudentGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentGroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateAsync(StudentGroupCreationDTO studentGroupCreationDto)
        {
            var studentGroup = _mapper.Map<StudentGroup>(studentGroupCreationDto);

            _unitOfWork.StudentGroups.Create(studentGroup);
            await _unitOfWork.Complete();
        }

        public async Task DeleteAsync(int id)
        {
            _unitOfWork.StudentGroups.Delete(id);
            await _unitOfWork.Complete();
        }

        public async Task<StudentGroupFullInfoDTO> FindByIdAsync(int id)
        {
            var studentGroup = await _unitOfWork.StudentGroups.GetByIdAsync(id);

            return _mapper.Map<StudentGroupFullInfoDTO>(studentGroup);
        }

        public async Task<IEnumerable<StudentGroupDTO>> GetAllAsync()
        {
            var studentGroups = await _unitOfWork.StudentGroups.GetAllAsync();

            return _mapper.Map<List<StudentGroupDTO>>(studentGroups);
        }

        public async Task UpdateAsync(StudentGroupFullInfoDTO studentGroupUpdationDto)
        {
            var studentGroup = _mapper.Map<StudentGroup>(studentGroupUpdationDto);

            _unitOfWork.StudentGroups.Update(studentGroup);
            await _unitOfWork.Complete();
        }
    }
}
