using EducationalCenter.Common.Dtos.Api.Request;
using EducationalCenter.Common.Dtos.Log;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EducationalCenter.BLL.Interfaces
{
    public interface ILogsService
    {
        Task<IEnumerable<LogDto>> GetLogsAsync(GetLogsRequest filter, CancellationToken cancellationToken);
    }
}
