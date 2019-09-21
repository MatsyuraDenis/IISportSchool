using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class EFServiceRepository : IServiceRepository
    {
        ApplicationDbContext _context;
        private bool disposed = false;
        public EFServiceRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public void CreateDepartment(Department department)
        {
            _context.Departments.Add(department);
        }

        public void CreateSection(Section section)
        {
            _context.Sections.Add(section);
        }

        public void DeleteSection(Section section)
        {
            _context.Sections.Remove(section);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                    _context = null;
                }                    
            }
            disposed = true;
        }

        public Department GetDepartment(int id)
        {
            return _context.Departments.Include(d=>d.Sections).SingleOrDefault(d=>d.Id == id);
        }

        public Section GetSection(int id)
        {
            return _context.Sections.SingleOrDefault(s => s.Id == id);
        }

        public Section GetSectionWithGroups(int id)
        {
            return _context.Sections.Include(s => s.Groups).SingleOrDefault(s => s.Id == id);
        }

        public Section GetSectionFull(int id)
        {
            return _context.Sections.Include(s => s.Groups).Include(s=>s.Department).SingleOrDefault(s => s.Id == id);
        }

        public IQueryable<Department> Departments => _context.Departments;

        public IQueryable<Section> ListOfSections()
        {
            return _context.Sections;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateDepartment(Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
        }

        public void UpdateSection(Section section)
        {
            _context.Entry(section).State = EntityState.Modified;
        }
    }
}
