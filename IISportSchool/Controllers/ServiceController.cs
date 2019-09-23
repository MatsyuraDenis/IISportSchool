using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IISportSchool.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using IISportSchool.Models.FluentValidators;
using System.IO;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IISportSchool.Controllers
{
    public class ServiceController : Controller
    {
        AbstractDepartmentDeleter _deleter;
        IServiceRepository _services;
        public ServiceController(AbstractDepartmentDeleter deleter, IServiceRepository service)
        {
            _deleter = deleter;
            _services = service;
        }
        // GET: /<controller>/
        public IActionResult DepartmentList()
        {
            var dep = _services.Departments.Include(d => d.Sections).ToList();
            return View(dep);
        }
        public IActionResult DepartmentDetails(int? id)
        {
            if (id == null || id == 0)
                return BadRequest();

            var department = _services.GetDepartment((int)id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        [HttpGet]
        [Authorize(Roles = DefaultRoles.Admin)]
        public IActionResult AddDepartment()
        {
            Department department = new Department { ImagePath = @"~/images/departmentLogos/" };
            return View(department);
        }

        [Authorize(Roles = DefaultRoles.Admin)]
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
            _services.CreateDepartment(department);
            _services.Save();

            return RedirectToAction("DepartmentList");
        }


        [Authorize(Roles = DefaultRoles.Admin)]
        public IActionResult UpdateDepartment(int? id)
        {
            if (id == null || id == 0)
                return BadRequest();

            var department = _services.GetDepartment((int)id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        [Authorize(Roles = DefaultRoles.Admin)]
        [HttpPost]
        public IActionResult UpdateDepartment(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }

            _services.UpdateDepartment(department);
            _services.Save();
            return RedirectToAction("DepartmentList");
        }


        [Authorize(Roles = DefaultRoles.Admin)]
        public IActionResult DeleteDepartment(int? id)
        {
            if (id == null || id == 0)
                return BadRequest();

            var department = _services.Departments.SingleOrDefault(d => d.Id == id);

            if (department == null)
                return NotFound();

            return View(department);
        }


        [Authorize(Roles = DefaultRoles.Admin)]
        public IActionResult DeleteDepartmentConfirmed(int Id)
        {
            _deleter.DeleteDepartment(Id);

            return RedirectToAction("DepartmentList");
        }


        [Authorize(Roles = DefaultRoles.Admin)]
        public IActionResult AddSection(int departmentId = 0)
        {
            Section section = new Section
            {
                DepartmentId = departmentId,
                ImagePath = @"~/images/sections/"
            };
            ViewBag.Department = _services.GetDepartment(departmentId);
            //ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name");
            return View(section);
        }


        [Authorize(Roles = DefaultRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSection(Section section)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Department = _services.GetDepartment(section.DepartmentId);
                return View(section);
            }
            if (section == null)
                return BadRequest();

            _services.CreateSection(section);
            _services.Save();
            return RedirectToAction("DepartmentList");
        }

        public IActionResult SectionDetails(int? id)
        {
            if (id == null)
                return BadRequest();

            var section = _services.GetSection((int)id);

            if (section == null)
                return NotFound();

            return View(section);
        }

        [Authorize(Roles = DefaultRoles.Admin)]
        public IActionResult DeleteSection(int? id)
        {
            if (id == null)
                return BadRequest();

            var section = _services.ListOfSections()
                .Include(s => s.Department)
                .SingleOrDefault(s => s.Id == id);

            if (section == null)
                return NotFound();

            return View(section);
        }

        [Authorize(Roles = DefaultRoles.Admin)]
        public IActionResult DeleteSectionConfirmed(int? id)
        {
            var section = _services.ListOfSections()
                .Include(s => s.Department)
                .SingleOrDefault(s => s.Id == id);

            if(section != null)
            {
                _services.DeleteSection(section);
                _services.Save();
            }

            return RedirectToAction("DepartmentList");
        }


        [Authorize(Roles = DefaultRoles.Admin)]
        public IActionResult UpdateSection(int? id)
        {
            if (id == 0 || id == null)
                return BadRequest();

            var section = _services.GetSectionWithGroups((int)id);

            if (section == null)
                return NotFound();

            if (string.IsNullOrEmpty(section.ImagePath))
                section.ImagePath = @"images\sections\";

            return View(section);
        }

        [Authorize(Roles = DefaultRoles.Admin)]
        [HttpPost]
        public IActionResult UpdateSection(Section section)
        {
            _services.UpdateSection(section);
            _services.Save();
            return RedirectToAction("DepartmentList");
        }
    }
}
