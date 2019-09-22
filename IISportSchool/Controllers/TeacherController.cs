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
        private ITeacherRepository _repository;
        private IServiceRepository _schoolServices;
        private IPositionFactory _positionFactory;
        private IGroupRepository _groupRepository;
        private TeacherFactory _factory;
        private TeacherProxyFactory _proxyFactory;
        public TeacherController(ITeacherRepository repository, IServiceRepository serviceRepository,
            IPositionRepository positionRepository, ApplicationDbContext context,
            IGroupRepository groupRepository)
        {
            _repository = repository;
            _schoolServices = serviceRepository;
            _groupRepository = groupRepository;
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
                return View(viewModel);

            var sectionName = _schoolServices.GetSection((int)viewModel.SectionId).Name;
            _repository.Add(_factory.Create(viewModel));
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
                return BadRequest();

            var teacher = _repository.GetTeacher((int)id);
            if (teacher == null)
                return NotFound();
            ViewBag.Groups = _groupRepository.Groups.Where(g => g.SectionId == teacher.SectionId);

            TeacherViewModel teacherViewModel = _factory.CreateViewModel(teacher);
            return View(teacherViewModel);
        }
        [HttpPost]
        public IActionResult Update(TeacherViewModel viewModel)
        {
            var teacher = _factory.Update(viewModel);
            _repository.Update(teacher);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Teacher teacher)
        {
            _repository.Delete(teacher);
            return RedirectToAction("Index");
        }
    }
}
