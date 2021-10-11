using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Dtos;
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
        private readonly IMapper _mapper;

        public DepartmentsController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
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
            var department = _mapper.Map<DepartmentDTO>(departmentCreationDTO);

            await _departmentService.CreateAsync(department);

            return Ok(OperationResultMessages.DepartmentCreated);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(DepartmentDTO departmentDTO)
        {
            await _departmentService.UpdateAsync(departmentDTO);

            return Ok(OperationResultMessages.DepartmentEdited);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentService.DeleteAsync(id);

            return Ok(OperationResultMessages.DepartmentDeleted);
        }
    }
}
