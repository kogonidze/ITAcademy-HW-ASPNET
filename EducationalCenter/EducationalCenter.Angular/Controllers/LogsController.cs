using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos.Api.Request;
using EducationalCenter.Common.Dtos.Api.Response;
using EducationalCenter.Common.Dtos.Log;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace EducationalCenter.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class LogsController : ControllerBase
    {
        private readonly ILogsService _logsService;

        public LogsController(ILogsService logsService)
        {
            _logsService = logsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLogs([FromQuery] GetLogsRequest request, CancellationToken cancellationToken)
        {
            int countOfLogs;

            var logs = await _logsService.GetLogsAsync(request, cancellationToken);

            if (request.DateFrom == null && request.DateTo == null && request.GlobalFilter == null && request.LogType == null)
            {
                countOfLogs = _logsService.Count();
            }
            else
            {
                countOfLogs = await _logsService.CountWithFilter(request);
            }


            return Ok(new PagedResult<LogDto> { Data = logs, CountAllDocuments = countOfLogs});
        }
    }
}
