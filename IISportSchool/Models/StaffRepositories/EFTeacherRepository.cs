using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class EFTeacherRepository : ITeacherRepository
    {
        private ApplicationDbContext _context;
        TeacherProxyFactory _proxyFactory;
        public EFTeacherRepository(ApplicationDbContext context)
        {
            _context = context;
            _proxyFactory = new TeacherProxyFactory(context);
        }
        public IQueryable<Teacher> Teachers => _context.Teachers;

        public Teacher Add(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return teacher;
        }

        public Teacher Delete(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return teacher;
        }

        public Teacher Delete(TeacherProxy proxy)
        {
            var teacher = proxy.LoadTeacher(this);
            return Delete(teacher);
        }

        public Teacher GetTeacher(int id)
        {
            return _context.Teachers.SingleOrDefault(t => t.Id == id);
        }

        public Teacher Update(Teacher teacher)
        {
            var dbTeacher = _context.Teachers.Attach(teacher);
            dbTeacher.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return teacher;
        }

        public Teacher Update(UpdateteacherViewModel teacher)
        {
            var dbTeacher = _context.Teachers.SingleOrDefault(t => t.Id == teacher.Id);
            dbTeacher.Name = teacher.Name;
            dbTeacher.SecondName = teacher.SecondName;
            dbTeacher.Salary = teacher.Salary;
            dbTeacher.YearsOfExperience = teacher.YearsOfExperience;
            var proxy = _proxyFactory.Get(dbTeacher.Id);
            var group = _context.Groups.SingleOrDefault(g => g.Id == teacher.GroupId);
            _context.SaveChanges();
            return dbTeacher;
        }
    }
}
