using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos.Teacher;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationalCenter.Controllers
{
    public class TeacherController : Controller
    {
        private ITeacherService _service;

        public TeacherController(ITeacherService service)
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
        public async Task<IActionResult> Create(TeacherCreationDTO teacher)
        {
            await _service.CreateAsync(teacher);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _service.FindByIdAsync(id.Value);

            if (teacher != null)
            {
                return View(teacher);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(TeacherFullInfoDTO teacher)
        {
            await _service.UpdateAsync(teacher);

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

            return RedirectToAction("Index");
        }
    }
}
