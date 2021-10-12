using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationalCenter.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ICourseService _courseService;
        private IMapper _mapper;

        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAllAsync();

            return Ok(courses);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseService.FindByIdAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Create(CourseCreationDTO courseCreationDTO)
        {
            var course = _mapper.Map<CourseFullInfoDTO>(courseCreationDTO);

            await _courseService.CreateAsync(course);

            return Ok(OperationResultMessages.CourseCreated);
        }

        [HttpPut]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Edit(CourseFullInfoDTO course)
        {
            await _courseService.UpdateAsync(course);

            return Ok(OperationResultMessages.CourseEdited);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseService.DeleteAsync(id);

            return Ok(OperationResultMessages.CourseDeleted);
        }
    }
}