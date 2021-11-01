using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Constants;
using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Enums;
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
        private ILoggerService _loggerService;
        private IMapper _mapper;

        public CoursesController(ICourseService courseService, IMapper mapper, ILoggerService loggerService)
        {
            _courseService = courseService;
            _mapper = mapper;
            _loggerService = loggerService;
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
            _loggerService.GenerateRequestLog(courseCreationDTO, LogType.CoursesCreationRequest);

            var course = _mapper.Map<CourseFullInfoDTO>(courseCreationDTO);

            await _courseService.CreateAsync(course);

            var response = OperationResultMessages.CourseCreated;

            _loggerService.GenerateResponseLog(courseCreationDTO, response, LogType.CoursesCreationRequest);

            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Edit(CourseFullInfoDTO course)
        {
            _loggerService.GenerateRequestLog(course, LogType.CoursesEditionRequest);

            await _courseService.UpdateAsync(course);

            var response = OperationResultMessages.CourseEdited;

            _loggerService.GenerateResponseLog(course, response, LogType.CoursesEditionRequest);

            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Delete(int id)
        {
            _loggerService.GenerateRequestLog(id, LogType.CoursesDeletionRequest);

            await _courseService.DeleteAsync(id);

            var response = OperationResultMessages.CourseDeleted;

            _loggerService.GenerateResponseLog(id, response, LogType.CoursesDeletionRequest);

            return Ok(response);
        }
    }
}