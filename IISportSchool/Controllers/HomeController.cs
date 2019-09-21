using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IISportSchool.Models;

namespace IISportSchool.Controllers
{
    public class HomeController : Controller
    {
        private IServiceRepository _serviceRepository;

        public HomeController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.Departments = _serviceRepository.Departments;
            viewModel.ImagePath = @"~/images/home/school.jpg";
            viewModel.Initialize();
            return View(viewModel);
        }
    }
}