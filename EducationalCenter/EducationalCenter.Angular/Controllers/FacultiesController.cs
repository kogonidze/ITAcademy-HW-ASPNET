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
    public class FacultiesController : ControllerBase
    {
        private readonly IFacultyService _facultyService;
        private readonly IMapper _mapper;

        public FacultiesController(IFacultyService facultyService, IMapper mapper)
        {
            _facultyService = facultyService;
            _mapper = mapper;
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
            var faculty = _mapper.Map<FacultyDTO>(facultyCreationDTO);

            await _facultyService.CreateAsync(faculty);

            return Ok(OperationResultMessages.FacultyCreated);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(FacultyDTO facultyDTO)
        {
            await _facultyService.UpdateAsync(facultyDTO);

            return Ok(OperationResultMessages.FacultyEdited);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _facultyService.DeleteAsync(id);

            return Ok(OperationResultMessages.FacultyDeleted);
        }
    }
}
