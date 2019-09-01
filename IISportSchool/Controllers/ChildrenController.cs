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
    }
}
