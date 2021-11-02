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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private ILoggerService _loggerService;
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartmentService departmentService, IMapper mapper, ILoggerService loggerService)
        {
            _departmentService = departmentService;
            _mapper = mapper;
            _loggerService = loggerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetAllAsync();

            return Ok(departments);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentService.FindByIdAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(DepartmentCreationDTO departmentCreationDTO)
        {
            _loggerService.GenerateRequestLog(departmentCreationDTO, LogType.DepartmentCreationRequest);

            var department = _mapper.Map<DepartmentDTO>(departmentCreationDTO);

            await _departmentService.CreateAsync(department);

            var response = OperationResultMessages.DepartmentCreated;

            _loggerService.GenerateResponseLog(departmentCreationDTO, response, LogType.DepartmentCreationRequest);

            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(DepartmentDTO departmentDTO)
        {
            _loggerService.GenerateRequestLog(departmentDTO, LogType.DepartmentEditionRequest);

            await _departmentService.UpdateAsync(departmentDTO);

            var response = OperationResultMessages.DepartmentEdited;

            _loggerService.GenerateResponseLog(departmentDTO, response, LogType.DepartmentEditionRequest);

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            _loggerService.GenerateRequestLog(id, LogType.DepartmentDeletionRequest);

            await _departmentService.DeleteAsync(id);

            var response = OperationResultMessages.DepartmentDeleted;

            _loggerService.GenerateResponseLog(id, response, LogType.DepartmentDeletionRequest);

            return Ok(response);
        }
    }
}
