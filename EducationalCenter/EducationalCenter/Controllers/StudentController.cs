using Microsoft.AspNetCore.Mvc;
using EducationalCenter.Common.Dtos.Student;
using EducationalCenter.BLL.Interfaces;
using System.Threading.Tasks;
using System;

namespace EducationalCenter.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _studentService;
        private IStudentGroupService _studentGroupService;

        public StudentController(IStudentService service, IStudentGroupService studentGroupService)
        {
            _studentService = service;
            _studentGroupService = studentGroupService;
        }

        public async Task<IActionResult> Index()
        {
            var obj = await _studentService.GetAllAsync();
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Groups = await _studentGroupService.GetAllAsync();
            var newStudent = new StudentFullInfoDTO() { DateOfBirth = DateTime.Now };

            return View("Edit", newStudent);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _studentService.FindByIdAsync(id.Value);

            if (student != null)
            {
                ViewBag.Groups = await _studentGroupService.GetAllAsync();
                return View(student);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(StudentFullInfoDTO student)
        {
            if (ModelState.IsValid)
            {
                if (student.Id > 0)
                    await _studentService.UpdateAsync(student);
                else
                    await _studentService.CreateAsync(student);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _studentService.DeleteAsync(id.Value);

            return RedirectToAction("Index");
        }
    }
}
