using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Dtos.Api.Request;
using EducationalCenter.Common.Dtos.Api.Response;
using EducationalCenter.Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationalCenter.Angular.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    [Authorize(Roles = "admin, manager")]
    public class TeachersController : ControllerBase
    {
        private ITeacherService _teacherService;
        private ILoggerService _loggerService;
        private IMapper _mapper;

        public TeachersController(ITeacherService teacherService, IMapper mapper, ILoggerService loggerService)
        {
            _teacherService = teacherService;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 20)
        {
            var request = new IndexTeachersRequest();

            _loggerService.GenerateRequestLog(request, LogType.TeacherIndexingRequest);

            var teachers = await _teacherService.GetAllAsync(page, pageSize);
            var countAllTeachers = _teacherService.Count();

            _loggerService.GenerateResponseLog(request, teachers, LogType.TeacherIndexingRequest);

            return Ok(new PagedResult<TeacherDTO> { Data = teachers, CountAllDocuments = countAllTeachers });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            _loggerService.GenerateRequestLog(id, LogType.TeacherInfoRequest);

            var teacher = await _teacherService.FindByIdAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            _loggerService.GenerateResponseLog(id, teacher, LogType.TeacherInfoRequest);

            return Ok(teacher);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetByFilter([FromQuery] GetFilteredTeachersRequest request)
        {
            _loggerService.GenerateRequestLog(request, LogType.TeacherSearchRequest);

            var teachers = await _teacherService.GetByFilterAsync(request);
            var countOfTeachers = await _teacherService.CountWithFilter(request);

            _loggerService.GenerateResponseLog(request, teachers, LogType.TeacherSearchRequest);

            if (teachers == null)
            {
                return NotFound();
            }

            return Ok(new PagedResult<TeacherDTO> { Data = teachers, CountAllDocuments = countOfTeachers });
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherCreationDTO teacherCreationDTO)
        {
            _loggerService.GenerateRequestLog(teacherCreationDTO, LogType.TeacherCreationRequest);

            var teacher = _mapper.Map<TeacherFullInfoDTO>(teacherCreationDTO);

            await _teacherService.CreateAsync(teacher);

            var response = OperationResultMessages.TeacherCreated;

            _loggerService.GenerateResponseLog(teacherCreationDTO, response, LogType.TeacherCreationRequest);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(TeacherFullInfoDTO teacher)
        {
            _loggerService.GenerateRequestLog(teacher, LogType.TeacherEditionRequest);

            await _teacherService.UpdateAsync(teacher);

            var response = OperationResultMessages.TeacherEdited;

            _loggerService.GenerateResponseLog(teacher, response, LogType.TeacherEditionRequest);

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            _loggerService.GenerateRequestLog(id, LogType.TeacherDeletionRequest);

            await _teacherService.DeleteAsync(id);

            var response = OperationResultMessages.TeacherDeleted;

            _loggerService.GenerateResponseLog(id, response, LogType.TeacherDeletionRequest);

            return Ok(response);
        }
    }
}
