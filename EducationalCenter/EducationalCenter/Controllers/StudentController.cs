using Microsoft.AspNetCore.Mvc;
using EducationalCenter.Common.Dtos.Student;
using EducationalCenter.BLL.Interfaces;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using ElmahCore;
using EducationalCenter.Models;
using System.Diagnostics;

namespace EducationalCenter.Controllers
{
    [Authorize]
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
            try
            {
                var obj = await _studentService.GetAllAsync();
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
        public async Task<IActionResult> Create()
        {
            try
            {
                ViewBag.Groups = await _studentGroupService.GetAllAsync();
                var newStudent = new StudentFullInfoDTO() { DateOfBirth = DateTime.Now };

                return View("Edit", newStudent);
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
                    return NotFound();

                var student = await _studentService.FindByIdAsync(id.Value);

                if (student != null)
                {
                    ViewBag.Groups = await _studentGroupService.GetAllAsync();
                    return View(student);
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
        [Authorize(Roles = "admin, manager")]
        public async Task<ActionResult> Edit(StudentFullInfoDTO student)
        {
            try
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

                await _studentService.DeleteAsync(id.Value);

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
