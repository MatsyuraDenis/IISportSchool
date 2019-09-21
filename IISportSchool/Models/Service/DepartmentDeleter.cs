using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class DepartmentDeleter : AbstractDepartmentDeleter
    {
        ApplicationDbContext _context;
        public DepartmentDeleter(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
            this.disposed = true;
        }

        protected override void Delete(int departmentId)
        {
            var department = _context.Departments.SingleOrDefault(d => d.Id == departmentId);
            if (department != null)
                _context.Departments.Remove(department);

            _context.SaveChanges();
        }

        protected override void DeleteGroups(List<Group> groups)
        {
            if (groups != null && groups.Count() > 0)
                _context.Groups.RemoveRange(groups);
        }

        protected override void DeleteSections(List<Section> sections)
        {
            if (sections != null && sections.Count() > 0)
                _context.Sections.RemoveRange(sections);
        }

        protected override List<Group> GetGroups(List<Section> sections)
        {
            List<Group> groups = new List<Group>();
            foreach (var section in sections)
                groups.AddRange(section.Groups);
            return groups;
        }

        protected override List<Section> GetSections(int departmentId)
        {
            return _context.Sections
                .Where(s => s.DepartmentId == departmentId)
                .Include(s => s.Groups)
                .ToList();
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
