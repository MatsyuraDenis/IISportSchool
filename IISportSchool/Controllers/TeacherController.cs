using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IISportSchool.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IISportSchool.Controllers
{
    public class TeacherController : Controller
    {
        private ITeacherRepository _repository;
        private IServiceRepository _schoolServices;
        private IPositionFactory _positionFactory;
        private IGroupRepository _groupRepository;
        private TeacherFactory _factory;
        private TeacherProxyFactory _proxyFactory;

        private IHostingEnvironment _hostingEnviroment;

        public TeacherController(ITeacherRepository repository, IServiceRepository serviceRepository,
            IPositionRepository positionRepository, ApplicationDbContext context,
            IGroupRepository groupRepository, IHostingEnvironment hostingEnviroment)
        {
            _repository = repository;
            _schoolServices = serviceRepository;
            _groupRepository = groupRepository;
            _hostingEnviroment = hostingEnviroment;
            _proxyFactory = new TeacherProxyFactory(context);
            _positionFactory = new PositionFactory(positionRepository);
            _factory = new TeacherFactory(context, _positionFactory);
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<TeacherProxy> proxies = new List<TeacherProxy>();
            foreach (var teacher in _repository.Teachers)
                proxies.Add(_proxyFactory.Get(teacher.Id));
            return View(proxies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            TeacherViewModel viewModel = new TeacherViewModel();
            viewModel.Sections = _schoolServices.ListOfSections().ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(TeacherViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Sections = _schoolServices.ListOfSections().ToList();
                return View(viewModel);
            }
                

            string uniqueFileName = null;
            if(viewModel.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnviroment.WebRootPath, "images", "teachers");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                viewModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            IPositionStrategy strategy = new PositionStrategy();
            string name = strategy.CreatePosition(viewModel.SectionId);
            var sectionName = _schoolServices.GetSection((int)viewModel.SectionId).Name;
            Teacher teacher = _factory.Create(viewModel);
            Position position = _positionFactory.GetPosition(name);
            teacher.Position = position;
            teacher.PhotoPath = uniqueFileName;
            _repository.Add(teacher);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
                return BadRequest();

            var teacher = _repository.GetTeacher((int)id);
            if (teacher == null)
                return NotFound();

            UpdateteacherViewModel teacherViewModel = _factory.UpdateViewModel(teacher);
            return View(teacherViewModel);
        }

        [HttpPost]
        public IActionResult Update(UpdateteacherViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            _repository.Update(viewModel);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Teacher teacher)
        {
            _repository.Delete(teacher);
            return RedirectToAction("Index");
        }
    }
}
