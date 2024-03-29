﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IISportSchool.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IISportSchool.Controllers
{
    public class ChildrenController : Controller
    {
        private IChildrenRepository _repository;
        public ChildrenController(IChildrenRepository repository)
        {
            _repository = repository;
        }

        public IActionResult List()
        {
            return View(_repository.Children);
        }

        [Authorize(Roles = DefaultRoles.Admin)]
        public IActionResult Add(int groupId, string groupName, int minAge, int maxAge)
        {
            AddChildViewModel viewModel = new AddChildViewModel
            {
                Children = new Children { GroupId = groupId },
                MinAge = minAge,
                MaxAge = maxAge
            };
            ViewBag.Group = groupName;
            return View(viewModel);
        }

        [Authorize(Roles = DefaultRoles.Admin)]
        [HttpPost]
        public IActionResult Add(AddChildViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            _repository.Add(viewModel.Children);
            return RedirectToAction("Details", "Group", new { id = viewModel.Children.GroupId});
        }

        [Authorize(Roles = DefaultRoles.Admin)]
        public IActionResult Edit(int? id,int groupId, string groupName, int minAge, int maxAge)
        {
            if (id == null || id == 0)
                return BadRequest();

            var child = _repository.GetChildren((int)id);

            if (child == null)
                return NotFound();


            AddChildViewModel viewModel = new AddChildViewModel
            {
                Children = child,
                MinAge = minAge,
                MaxAge = maxAge
            };
            ViewBag.Group = groupName;
            return View(viewModel);
        }

        [Authorize(Roles = DefaultRoles.Admin)]
        [HttpPost]
        public IActionResult Edit(AddChildViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            _repository.Update(viewModel.Children);
            return RedirectToAction("Details", "Group", new { id = viewModel.Children.GroupId });
        }


        [Authorize(Roles = DefaultRoles.Admin)]
        public IActionResult Delete(int? id)
        {
            if (id == null && id == 0)
                return BadRequest();

            var child = _repository.GetChildren((int)id);

            if (child == null)
                return NotFound();

            _repository.Delete(child);

            return RedirectToAction("Details", "Group", new { id = child.GroupId });
        }
    }
}
