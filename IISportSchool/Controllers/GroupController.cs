using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IISportSchool.Models;

namespace IISportSchool.Controllers
{
    public class GroupController : Controller
    {
        IGroupRepository _repository;
        public GroupController(IGroupRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.Groups);
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

        public IActionResult Update(Group group)
        {
            _repository.Update(group);
            _repository.Save();
            return RedirectToAction("Service", "SectionDetails", new { id = group.SectionId });
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