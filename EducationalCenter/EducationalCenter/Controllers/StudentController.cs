using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationalCenter.BL;
using EducationalCenter.IBL;
using EducationalCenter.ISL;
using EducationalCenter.Model;
using EducationalCenter.SL;
using EducationalCenter.SL.DTO;

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
    }
}
