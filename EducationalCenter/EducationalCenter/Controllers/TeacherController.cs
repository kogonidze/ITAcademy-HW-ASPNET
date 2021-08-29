using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos.Teacher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EducationalCenter.Controllers
{
    [Authorize]
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
        [Authorize(Roles = "admin, manager")]
        public IActionResult Create()
        {
            var newTeacher = new TeacherFullInfoDTO() { DateOfBirth = DateTime.Now };

            return View("Edit", newTeacher);
        }

        [HttpGet]
        [Authorize(Roles = "admin, manager")]
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
        [Authorize(Roles = "admin,manager")]
        public async Task<ActionResult> Edit(TeacherFullInfoDTO teacher)
        {
            if (teacher.Id > 0)
                await _service.UpdateAsync(teacher);
            else
                await _service.CreateAsync(teacher);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
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
