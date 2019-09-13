using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IISportSchool.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using IISportSchool.Models.FluentValidators;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IISportSchool.Controllers
{
    public class ServiceController : Controller
    {
        private ApplicationDbContext _context;
        public ServiceController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult DepartmentList()
        {
            return View(_context.Departments.Include(d=>d.Sections).ToList());
        }

        public IActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            if (department == null)
                return BadRequest();

            _context.Departments.Add(department);
            _context.SaveChanges();

            return RedirectToAction("DepartmentList");
        }

        public IActionResult AddSection(int departmentId = 0)
        {
            Section section = new Section
            {
                DepartmentId = departmentId                
            };
            ViewBag.Department = _context.Departments.SingleOrDefault(d => d.Id == departmentId);
            //ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name");
            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSection(Section section)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Department = _context.Departments.SingleOrDefault(d => d.Id == section.DepartmentId);
                return View(section);
            }
            if (section == null)
                return BadRequest();

            _context.Sections.Add(section);
            _context.SaveChanges();
            return RedirectToAction("DepartmentList");
        }

        public IActionResult SectionDetails(int? id)
        {
            if (id == null)
                return BadRequest();

            var section = _context.Sections
                .Include(s=>s.Department)
                .SingleOrDefault(s => s.Id == id);

            if (section == null)
                return NotFound();

            return View(section);
        }
        public IActionResult DeleteSection(int? id)
        {
            if (id == null)
                return BadRequest();

            var section = _context.Sections
                .Include(s => s.Department)
                .SingleOrDefault(s => s.Id == id);

            if (section == null)
                return NotFound();

            return View(section);
        }
        public IActionResult DeleteSectionConfirmed(int? id)
        {
            var section = _context.Sections
                .Include(s => s.Department)
                .SingleOrDefault(s => s.Id == id);

            if(section != null)
            {
                _context.Sections.Remove(section);
                _context.SaveChanges();
            }

            return RedirectToAction("DepartmentList");
        }
    }
}
