using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos;
using EducationalCenter.Common.Dtos.Teacher;
using EducationalCenter.Models;
using ElmahCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EducationalCenter.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private ITeacherService _teacherService;
        private IDepartmentService _departmentService;
        private IMapper _mapper;

        public TeacherController(ITeacherService teacherService, IDepartmentService departmentService, IMapper mapper)
        {
            _teacherService = teacherService;
            _departmentService = departmentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var obj = await _teacherService.GetAllAsync();
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
                ViewBag.Departments = _mapper.Map<IEnumerable<DepartmentDTO>>(await _departmentService.GetAllAsync());
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

                var teacher = await _teacherService.FindByIdAsync(id.Value);

                if (teacher != null)
                {
                    ViewBag.Departments = _mapper.Map<IEnumerable<DepartmentDTO>>(await _departmentService.GetAllAsync());
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
                    await _teacherService.UpdateAsync(teacher);
                else
                    await _teacherService.CreateAsync(teacher);

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

                await _teacherService.DeleteAsync(id.Value);

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
