using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos.Api.Request;
using EducationalCenter.Common.Dtos.Log;
using EducationalCenter.Common.Models;
using EducationalCenter.DataAccess.EF.Interfaces;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace EducationalCenter.BLL.Services
{
    public class LogsService : ILogsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LogsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LogDto>> GetLogsAsync(GetLogsRequest filter, CancellationToken cancellationToken)
        {
            IEnumerable<Log> logs;

            filter.SortOrder = filter.SortOrder ?? -1;

            var filters = BuildFilter(filter);

            if (filters != null)
            {
                logs = await _unitOfWork.Logs.GetByFilterAsync(filters);
            }
            else
            {
                logs = await _unitOfWork.Logs.GetAllAsync();
            }
            
            var report = _mapper.Map<List<LogDto>>(logs);

            return report;
        }

        private Expression<Func<Log, bool>> BuildFilter(GetLogsRequest filter)
        {
            Expression<Func<Log, bool>> finalFilter = el => el.Id > 1;

            var filters = GetAllFilters(filter);

            foreach (var item in filters)
            {
                finalFilter = finalFilter.And(item);
            }

            return finalFilter;
        }

        private List<Expression<Func<Log, bool>>> GetAllFilters(GetLogsRequest filter)
        {
            var filters = new List<Expression<Func<Log, bool>>>();

            if (!string.IsNullOrWhiteSpace(filter.GlobalFilter))
            {
                filters.Add(el => el.UserName == filter.GlobalFilter || el.IP == filter.GlobalFilter);
            }

            if (filter.LogType != null)
            {
                filters.Add(el => el.LogType == filter.LogType);
            }

            if (filter.DateFrom.HasValue)
            {
                filters.Add(el => el.TimeStamp >= filter.DateFrom);
            }

            if (filter.DateTo.HasValue)
            {
                filters.Add(el => el.TimeStamp <= filter.DateTo);
            }

            return filters;
        }
    }
}
