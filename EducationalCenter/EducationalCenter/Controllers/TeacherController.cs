using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos.Teacher;
using EducationalCenter.Models;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
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
            try
            {
                var obj = await _service.GetAllAsync();
                return View(obj);
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin, manager")]
        public IActionResult Create()
        {
            try
            {
                var newTeacher = new TeacherFullInfoDTO() { DateOfBirth = DateTime.Now };

                return View("Edit", newTeacher);
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin, manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            try
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
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin,manager")]
        public async Task<ActionResult> Edit(TeacherFullInfoDTO teacher)
        {
            try
            {
                if (teacher.Id > 0)
                    await _service.UpdateAsync(teacher);
                else
                    await _service.CreateAsync(teacher);

                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                await _service.DeleteAsync(id.Value);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ElmahExtensions.RiseError(new Exception(e.Message));
                return RedirectToAction("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
