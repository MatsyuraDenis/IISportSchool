using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IISportSchool.Models;
using Microsoft.AspNetCore.Authorization;

namespace IISportSchool.Controllers
{
    [Authorize(Roles = DefaultRoles.Admin)]
    public class GroupController : Controller
    {
        IGroupRepository _repository;
        ITeacherRepository _teachers;
        TeacherProxyFactory _teacherProxyFactory;
        public GroupController(IGroupRepository repository, ITeacherRepository teacher, ApplicationDbContext context)
        {
            _repository = repository;
            _teachers = teacher;
            _teacherProxyFactory = new TeacherProxyFactory(context);
        }
        public IActionResult Index()
        {
            var groups = _repository.Groups;
            return View(groups);
        }

        public IActionResult Details(int? id)
        {
            if (id == 0 || id == null)
                return BadRequest();

            var group = _repository.Get((int)id);
            if (group == null)
                return NotFound();
            return View(group);
        }

        public IActionResult Create(int sectionId, string sectionName="")
        {
            var group = new Group { SectionId = sectionId };
            ViewBag.Section = sectionName;
            return View(group);
        }
        [HttpPost]
        public IActionResult Create(Group group)
        {
            if (!ModelState.IsValid)
            {
                return View(group);
            }
            _repository.Add(group);
            _repository.Save();
            return RedirectToAction("SectionDetails", "Service", new { id = group.SectionId });
        }


        public IActionResult Update(int? id)
        {
            if (id == null && id == 0)
                return BadRequest();

            var group = _repository.Get((int)id);
            if (group == null)
                return NotFound();

            return View(group);
        }
        [HttpPost]
        public IActionResult Update(Group group)
        {
            _repository.Update(group);
            _repository.Save();
            return RedirectToAction("UpdateSection", "Service", new { id = group.SectionId });
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return BadRequest();

            var group = _repository.Get((int)id);

            if (group == null)
                return NotFound();

            _repository.Delete(group);
            _repository.Save();

            return RedirectToAction("UpdateSection", "Service", new { id = group.SectionId});
        }
        //[HttpPost]
        //public IActionResult Delete(Group group)
        //{
        //    _repository.Delete(group);
        //    _repository.Save();
        //    return RedirectToAction("Service", "SectionDetails", new { id = group.SectionId });
        //}
    }
}