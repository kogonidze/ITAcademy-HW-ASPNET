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

        public IActionResult Create()
        {
            return View();
        }
    }
}
