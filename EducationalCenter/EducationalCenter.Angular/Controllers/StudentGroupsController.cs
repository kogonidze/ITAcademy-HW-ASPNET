using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Dtos;
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
        private readonly IMapper _mapper;

        public StudentGroupsController(IStudentGroupService studentGroupService, IMapper mapper)
        {
            _studentGroupService = studentGroupService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var studentGroups = await _studentGroupService.GetAllAsync();

            return Ok(studentGroups);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var studentGroup = await _studentGroupService.FindByIdAsync(id);

            if (studentGroup == null)
            {
                return NotFound();
            }

            return Ok(studentGroup);
        }

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Create(StudentGroupCreationDTO studentGroupCreationDto)
        {
            var studentGroup = _mapper.Map<StudentGroupFullInfoDTO>(studentGroupCreationDto);

            await _studentGroupService.CreateAsync(studentGroup);

            return Ok(OperationResultMessages.StudentGroupCreated);
        }

        [HttpPut]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Edit(StudentGroupFullInfoDTO studentGroupFullInfoDTO)
        {
            await _studentGroupService.UpdateAsync(studentGroupFullInfoDTO);

            return Ok(OperationResultMessages.StudentGroupEdited);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentGroupService.DeleteAsync(id);

            return Ok(OperationResultMessages.StudentGroupDeleted);
        }
    }
}
