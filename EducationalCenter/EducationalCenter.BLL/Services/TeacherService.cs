using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Dtos.Api.Request;
using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public async Task CreateAsync(TeacherFullInfoDTO teacherCreationDto)
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

        public async Task<IEnumerable<TeacherDTO>> GetByFilterAsync(GetFilteredTeachersRequest filter)
        {
            var filters = BuildFilter(filter);

            var teachers = await _unitOfWork.Teachers.GetByFilterAsync(filters);

            var report = _mapper.Map<List<TeacherDTO>>(teachers);

            return report;
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

        private Expression<Func<Teacher, bool>> BuildFilter(GetFilteredTeachersRequest filter)
        {
            Expression<Func<Teacher, bool>> finalFilter = null;

            var filters = GetAllFilters(filter);

            var isFirst = true;

            foreach (var item in filters)
            {
                if (isFirst)
                {
                    finalFilter = item;

                    isFirst = false;
                }

                finalFilter = finalFilter.And(item);
            }

            return finalFilter;
        }

        private List<Expression<Func<Teacher, bool>>> GetAllFilters(GetFilteredTeachersRequest filter)
        {
            var filters = new List<Expression<Func<Teacher, bool>>>();

            if (!string.IsNullOrWhiteSpace(filter.FIO))
            {
                filters.Add(el => (el.FirstName + ' ' + el.LastName).Contains(filter.FIO));
            }

            if (filter.Experience.HasValue)
            {
                filters.Add(el => el.Experience >= filter.Experience);
            }

            if (filter.Category.HasValue)
            {
                filters.Add(el => (int)el.Category >= (int)filter.Category);
            }

            if (filter.Formation.HasValue)
            {
                filters.Add(el => (int)el.Formation >= (int)filter.Formation);
            }

            return filters;
        }
    }
}
