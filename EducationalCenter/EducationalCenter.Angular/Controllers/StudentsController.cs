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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin, manager")]
    public class StudentsController : ControllerBase
    {
        private IStudentService _studentService;
        private ILoggerService _loggerService;
        private IMapper _mapper;

        public StudentsController(IStudentService studentService, ILoggerService loggerService, IMapper mapper)
        {
            _studentService = studentService;
            _loggerService = loggerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 20)
        {
            var request = new IndexStudentsRequest();

            _loggerService.GenerateRequestLog(request, LogType.StudentIndexingRequest);

            var students = await _studentService.GetAllAsync(page, pageSize);
            var countAllStudents = _studentService.Count();

            _loggerService.GenerateResponseLog(request, students, LogType.StudentIndexingRequest);

            return Ok(new PagedResult<StudentDTO> { Data = students, CountAllDocuments = countAllStudents });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            _loggerService.GenerateRequestLog(id, LogType.StudentIndexingRequest);

            var student = await _studentService.FindByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            _loggerService.GenerateResponseLog(id, student, LogType.StudentIndexingRequest);

            return Ok(student);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetByFilter([FromQuery] GetFilteredStudentsRequest request)
        {
            _loggerService.GenerateRequestLog(request, LogType.StudentSearchRequest);

            var students = await _studentService.GetByFilterAsync(request);
            var countOfStudents = await _studentService.CountWithFilter(request);

            _loggerService.GenerateResponseLog(request, students, LogType.StudentSearchRequest);

            if (students == null)
            {
                return NotFound();
            }

            return Ok(new PagedResult<StudentDTO> { Data = students, CountAllDocuments = countOfStudents });
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreationDTO studentCreationDTO)
        {
            _loggerService.GenerateRequestLog(studentCreationDTO, LogType.StudentCreationRequest);

            var student = _mapper.Map<StudentFullInfoDTO>(studentCreationDTO);

            await _studentService.CreateAsync(student);

            var response = OperationResultMessages.StudentCreated;

            _loggerService.GenerateResponseLog(studentCreationDTO, response, LogType.StudentCreationRequest);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(StudentFullInfoDTO studentFullInfoDTO)
        {
            _loggerService.GenerateRequestLog(studentFullInfoDTO, LogType.StudentEditionRequest);

            await _studentService.UpdateAsync(studentFullInfoDTO);

            var response = OperationResultMessages.StudentEdited;

            _loggerService.GenerateResponseLog(studentFullInfoDTO, response, LogType.StudentEditionRequest);

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            _loggerService.GenerateRequestLog(id, LogType.StudentDeletionRequest);

            await _studentService.DeleteAsync(id);

            var response = OperationResultMessages.StudentDeleted;

            _loggerService.GenerateResponseLog(id, response, LogType.StudentDeletionRequest);

            return Ok(response);
        }
    }
}
