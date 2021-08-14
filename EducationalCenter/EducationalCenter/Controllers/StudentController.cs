using Microsoft.AspNetCore.Mvc;
using EducationalCenter.Common.Dtos.Student;
using EducationalCenter.BLL.Interfaces;
using System.Threading.Tasks;

namespace EducationalCenter.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _service.GetAllAsync();
            return View(obj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreationDTO student)
        {
            await _service.CreateAsync(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _service.FindByIdAsync(id.Value);

            if (student != null)
            {
                return View(student);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(StudentFullInfoDTO student)
        {
            await _service.UpdateAsync(student);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id.Value);

            //var student = await _service.FindByIdAsync(id.Value);

            //if (student != null)
            //{
            //    await _service.DeleteAsync(student);
            //}

            return RedirectToAction("Index");
        }
    }
}
