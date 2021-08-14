using Microsoft.AspNetCore.Mvc;
using EducationalCenter.Common.Dtos.Student;
using EducationalCenter.BLL.Interfaces;

namespace EducationalCenter.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var obj = _service.GetAll();
            return View(obj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentCreationDTO student)
        {
            _service.Create(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _service.FindById(id.Value);

            if (student != null)
            {
                return View(student);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(StudentFullInfoDTO student)
        {
            _service.Update(student);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _service.FindById(id.Value);

            if (student != null)
            {
                _service.Delete(student);
            }

            return RedirectToAction("Index");
        }
    }
}
