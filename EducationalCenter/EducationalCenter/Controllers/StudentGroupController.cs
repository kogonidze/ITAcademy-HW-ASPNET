using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos.StudentGroup;
using EducationalCenter.Common.Dtos.Teacher;
using EducationalCenter.Common.Models;
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
    public class StudentGroupController : Controller
    {
        private IStudentGroupService _studentGroupService;
        private ITeacherService _teacherService;
        private IMapper _mapper;

        public StudentGroupController(IStudentGroupService studentGroupService, ITeacherService teacherService, IMapper mapper)
        {
            _studentGroupService = studentGroupService;
            _teacherService = teacherService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var obj = await _studentGroupService.GetAllAsync();
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
                ViewBag.Teachers = _mapper.Map<IEnumerable<TeacherDTO>>(await _teacherService.GetAllAsync());
                var newStudentGroup = new StudentGroupFullInfoDTO();

                return View("Edit", newStudentGroup);
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

                var studentGroup = await _studentGroupService.FindByIdAsync(id.Value);

                if (studentGroup != null)
                {
                    ViewBag.Teachers = _mapper.Map<IEnumerable<TeacherDTO>>(await _teacherService.GetAllAsync());
                    return View(studentGroup);
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
        public async Task<ActionResult> Edit(StudentGroupFullInfoDTO studentGroup)
        {
            try
            {
                if (studentGroup.Id > 0)
                    await _studentGroupService.UpdateAsync(studentGroup);
                else
                    await _studentGroupService.CreateAsync(studentGroup);

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

                await _studentGroupService.DeleteAsync(id.Value);

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
