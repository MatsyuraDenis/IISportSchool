using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IISportSchool.Models;
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
        [HttpPost]
        public IActionResult Add(AddChildViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            _repository.Add(viewModel.Children);
            return RedirectToAction("Details", "Group", new { id = viewModel.Children.GroupId});
        }
    }
}
