using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Dtos.Api.Request;
using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;
using LinqKit;

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

        public async Task<IEnumerable<StudentDTO>> GetAllAsync(int page = 1, int pageSize = 20)
        {
            var students = await _unitOfWork.Students.GetAllAsync(page, pageSize);

            return _mapper.Map<List<StudentDTO>>(students);
        }

        public async Task CreateAsync(StudentFullInfoDTO studentCreationDto)
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

        public async Task<IEnumerable<StudentDTO>> GetByFilterAsync(GetFilteredStudentsRequest filter)
        {
            var filters = BuildFilter(filter);

            var students = await _unitOfWork.Students.GetByFilterAsync(filters, (int)filter.Page, (int)filter.PageSize);

            var report = _mapper.Map<List<StudentDTO>>(students);

            return report;
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

        public async Task<int> CountWithFilter(GetFilteredStudentsRequest filter)
        {
            var filters = BuildFilter(filter);

            var countOfStudents = await _unitOfWork.Students.CountWithFilter(filters);

            return countOfStudents;
        }

        private Expression<Func<Student, bool>> BuildFilter(GetFilteredStudentsRequest filter)
        {
            Expression<Func<Student, bool>> finalFilter = null;

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

        private List<Expression<Func<Student, bool>>> GetAllFilters(GetFilteredStudentsRequest filter)
        {
            var filters = new List<Expression<Func<Student, bool>>>();

            if (!string.IsNullOrWhiteSpace(filter.FIO))
            {
                filters.Add(el => (el.FirstName + ' ' + el.LastName).Contains(filter.FIO));
            }

            if (filter.GroupId.HasValue)
            {
                filters.Add(el => el.GroupId == filter.GroupId);
            }

            return filters;
        }

        public int Count()
        {
            return _unitOfWork.Students.Count();
        }
    }
}
