using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationalCenter.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentService _studentService;
        private IStudentGroupService _studentGroupService;

        public StudentsController(IStudentService service, IStudentGroupService studentGroupService)
        {
            _studentService = service;
            _studentGroupService = studentGroupService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();

            return Ok(students);
        }
    }
}
