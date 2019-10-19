using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class TeacherFactory
    {
        ApplicationDbContext _context;
        TeacherProxyFactory _proxyFactory;
        IPositionFactory _positionFactory;
        public TeacherFactory(ApplicationDbContext context, IPositionFactory positionFactory)
        {
            _context = context;
            _proxyFactory = new TeacherProxyFactory(context);
            _positionFactory = positionFactory;
        }
        public TeacherViewModel CreateViewModel(Teacher teacher)
        {
            TeacherViewModel viewModel = new TeacherViewModel
            {
                Name = teacher.Name,
                SecondName = teacher.SecondName,
                Salary = teacher.Salary,
                YearsOfExperience = teacher.YearsOfExperience,
                SectionName = teacher.SectionName
            };

            viewModel.Sections = _context.Sections.ToList();

            return viewModel;
        }
        public UpdateteacherViewModel UpdateViewModel(Teacher teacher)
        {
            UpdateteacherViewModel viewModel = new UpdateteacherViewModel
            {
                Name = teacher.Name,
                SecondName = teacher.SecondName,
                Salary = teacher.Salary,
                YearsOfExperience = teacher.YearsOfExperience,
                SectionName = teacher.SectionName,
                GroupId = teacher.GroupId,
                Groups = _context.Groups.Where(g => g.SectionId == teacher.SectionId).ToList()
            };

            return viewModel;
        }

        public Teacher Create(TeacherViewModel viewModel)
        {
            Teacher teacher = new Teacher
            {

                Name = viewModel.Name,
                SecondName = viewModel.SecondName,
                Salary = viewModel.Salary,
                YearsOfExperience = viewModel.YearsOfExperience,
                SectionId = viewModel.SectionId,
                Position = _positionFactory.GetPosition(DefaultPositions.Teacher)
            };

            teacher.SetSectionName(_context.Sections.Single(s => s.Id == viewModel.SectionId).Name);
            return teacher;
        }

        public Teacher Update(UpdateteacherViewModel viewModel)
        {
            Teacher teacher = new Teacher
            {
                Name = viewModel.Name,
                SecondName = viewModel.SecondName,
                Salary = viewModel.Salary,
                YearsOfExperience = viewModel.YearsOfExperience,
                Position = _positionFactory.GetPosition(DefaultPositions.Teacher)
            };
            return teacher;
        }
    }
}
