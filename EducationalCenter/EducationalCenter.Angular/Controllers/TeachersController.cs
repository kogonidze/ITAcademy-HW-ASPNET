using AutoMapper;
using EducationalCenter.BLL.Services;
using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Dtos;
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
        private TeacherService _teacherService;
        private IMapper _mapper;

        public TeachersController(TeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _teacherService.GetAllAsync();

            return Ok(teachers);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await _teacherService.FindByIdAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherCreationDTO teacherCreationDTO)
        {
            var teacher = _mapper.Map<TeacherFullInfoDTO>(teacherCreationDTO);

            await _teacherService.CreateAsync(teacher);

            return Ok(OperationResultMessages.TeacherCreated);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(TeacherFullInfoDTO teacher)
        {
            await _teacherService.UpdateAsync(teacher);

            return Ok(OperationResultMessages.TeacherEdited);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teacherService.DeleteAsync(id);

            return Ok(OperationResultMessages.TeacherDeleted);
        }
    }
}
