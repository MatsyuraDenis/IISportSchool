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
        private ApplicationDbContext _context;
        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_context.Teachers.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
