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
        public EFTeacherRepository(ApplicationDbContext context)
        {
            _context = context;
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
    }
}
