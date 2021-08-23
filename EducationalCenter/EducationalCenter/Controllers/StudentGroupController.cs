using AutoMapper;
using EducationalCenter.BLL.Interfaces;
using EducationalCenter.Common.Dtos.StudentGroup;
using EducationalCenter.Common.Dtos.Teacher;
using EducationalCenter.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EducationalCenter.Controllers
{
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
            var obj = await _studentGroupService.GetAllAsync();
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Teachers = _mapper.Map<IEnumerable<TeacherDTO>>(await _teacherService.GetAllAsync());
            var newStudentGroup = new StudentGroupFullInfoDTO();

            return View("Edit", newStudentGroup);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
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

        [HttpPost]
        public async Task<ActionResult> Edit(StudentGroupFullInfoDTO studentGroup)
        {
            if (studentGroup.Id > 0)
                await _studentGroupService.UpdateAsync(studentGroup);
            else
                await _studentGroupService.CreateAsync(studentGroup);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _studentGroupService.DeleteAsync(id.Value);

            return RedirectToAction("Index");
        }
    }
}
