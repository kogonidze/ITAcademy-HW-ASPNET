using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationalCenter.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly IFacultyService _facultyService;
        private ILoggerService _loggerService;
        private readonly IMapper _mapper;

        public FacultiesController(IFacultyService facultyService, IMapper mapper, ILoggerService loggerService)
        {
            _facultyService = facultyService;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var faculties = await _facultyService.GetAllAsync();

            return Ok(faculties);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var faculty = await _facultyService.FindByIdAsync(id);

            if (faculty == null)
            {
                return NotFound();
            }

            return Ok(faculty);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(FacultyCreationDTO facultyCreationDTO)
        {
            _loggerService.GenerateRequestLog(facultyCreationDTO, LogType.FacultyCreationRequest);

            var faculty = _mapper.Map<FacultyDTO>(facultyCreationDTO);

            await _facultyService.CreateAsync(faculty);

            var response = OperationResultMessages.FacultyCreated;

            _loggerService.GenerateResponseLog(facultyCreationDTO, response, LogType.FacultyCreationRequest);

            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(FacultyDTO facultyDTO)
        {
            _loggerService.GenerateRequestLog(facultyDTO, LogType.FacultyEditionRequest);

            await _facultyService.UpdateAsync(facultyDTO);

            var response = OperationResultMessages.FacultyEdited;

            _loggerService.GenerateResponseLog(facultyDTO, response, LogType.FacultyEditionRequest);

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            _loggerService.GenerateRequestLog(id, LogType.FacultyDeletionRequest);

            await _facultyService.DeleteAsync(id);

            var response = OperationResultMessages.FacultyDeleted;

            _loggerService.GenerateResponseLog(id, response, LogType.FacultyDeletionRequest);

            return Ok(response);
        }
    }
}
