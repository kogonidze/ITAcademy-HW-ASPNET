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
    [Authorize(Roles = "admin, manager")]
    public class StudentsController : ControllerBase
    {
        private IStudentService _studentService;
        private IMapper _mapper;

        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.FindByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreationDTO studentCreationDTO)
        {
            var student = _mapper.Map<StudentFullInfoDTO>(studentCreationDTO);

            await _studentService.CreateAsync(student);

            return Ok(OperationResultMessages.StudentCreated);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(StudentFullInfoDTO studentFullInfoDTO)
        {
             await _studentService.UpdateAsync(studentFullInfoDTO);

            return Ok(OperationResultMessages.StudentEdited);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeleteAsync(id);

            return Ok(OperationResultMessages.StudentDeleted);
        }
    }
}
