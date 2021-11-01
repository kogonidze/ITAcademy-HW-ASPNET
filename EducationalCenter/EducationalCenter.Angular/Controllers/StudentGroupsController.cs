using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Dtos.Api.Request;
using EducationalCenter.Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationalCenter.Angular.Controllers
{
    [Authorize]
    [Route("api/{controller}")]
    [ApiController]
    public class StudentGroupsController : ControllerBase
    {
        private readonly IStudentGroupService _studentGroupService;
        private ILoggerService _loggerService;
        private readonly IMapper _mapper;

        public StudentGroupsController(IStudentGroupService studentGroupService, IMapper mapper, ILoggerService loggerService)
        {
            _studentGroupService = studentGroupService;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = new IndexStudentGroupRequest();

            _loggerService.GenerateRequestLog(request, LogType.StudentGroupIndexingRequest);

            var studentGroups = await _studentGroupService.GetAllAsync();

            _loggerService.GenerateResponseLog(request, studentGroups, LogType.StudentGroupIndexingRequest);

            return Ok(studentGroups);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            _loggerService.GenerateRequestLog(id, LogType.StudentGroupInfoRequest);

            var studentGroup = await _studentGroupService.FindByIdAsync(id);

            if (studentGroup == null)
            {
                return NotFound();
            }

            _loggerService.GenerateResponseLog(id, studentGroup, LogType.StudentGroupInfoRequest);

            return Ok(studentGroup);
        }

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Create(StudentGroupCreationDTO studentGroupCreationDto)
        {
            _loggerService.GenerateRequestLog(studentGroupCreationDto, LogType.StudentGroupCreationRequest);

            var studentGroup = _mapper.Map<StudentGroupFullInfoDTO>(studentGroupCreationDto);

            await _studentGroupService.CreateAsync(studentGroup);

            var response = OperationResultMessages.StudentGroupCreated;

            _loggerService.GenerateResponseLog(studentGroupCreationDto, response, LogType.StudentGroupCreationRequest);

            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Edit(StudentGroupFullInfoDTO studentGroupFullInfoDTO)
        {
            _loggerService.GenerateRequestLog(studentGroupFullInfoDTO, LogType.StudentGroupEditionRequest);

            await _studentGroupService.UpdateAsync(studentGroupFullInfoDTO);

            var response = OperationResultMessages.StudentGroupEdited;

            _loggerService.GenerateResponseLog(studentGroupFullInfoDTO, response, LogType.StudentGroupEditionRequest);

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Delete(int id)
        {
            _loggerService.GenerateRequestLog(id, LogType.StudentGroupDeletionRequest);

            await _studentGroupService.DeleteAsync(id);

            var response = OperationResultMessages.StudentGroupDeleted;

            _loggerService.GenerateResponseLog(id, response, LogType.StudentGroupDeletionRequest);

            return Ok(response);
        }
    }
}
