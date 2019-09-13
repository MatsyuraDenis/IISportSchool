using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IISportSchool.Models
{
    public class DepartmentDeleter : IDepartmentDelete
    {
        private ApplicationDbContext _context;
        public DepartmentDeleter(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var department = _context.Departments
                .Include(d=>d.Sections.Select(s=>s.Groups))
                .SingleOrDefault(d => d.Id == id);
            Delete(department);
        }

        public void Delete(Department department)
        {
            var sections = _context.Sections.Where(s => s.DepartmentId == department.Id).ToList();
            List<Group> groups = new List<Group>();
            foreach (var section in sections)
            {
                groups.AddRange(section.Groups);
            }
            if (groups != null)
                DeleteGroups(groups);

            if (sections != null)
                DeleteSections(sections);

            if (department != null)
                DeleteDepartment(department);
            _context.SaveChanges();
        }

        public void DeleteDepartment(Department department)
        {
            _context.Departments.Remove(department);
        }

        public void DeleteGroups(List<Group> groups)
        {
            _context.Groups.RemoveRange(groups);
        }

        public void DeleteSections(List<Section> sections)
        {
            _context.Sections.RemoveRange(sections);
        }
    }
}
