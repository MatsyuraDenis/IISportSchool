using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IISportSchool.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IISportSchool.Controllers
{
    public class TeacherController : Controller
    {
        private ITeacherRepository _repository;
        public TeacherController(ITeacherRepository _repository)
        {
            this._repository = _repository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_repository.Teachers.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            _repository.Add(teacher);
            return RedirectToAction("Index");
        }
    }
}
