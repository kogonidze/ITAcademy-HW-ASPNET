using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos.Api.Request;
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
            var logs = await _logsService.GetLogsAsync(request, cancellationToken);

            return Ok(logs);
        }
    }
}
