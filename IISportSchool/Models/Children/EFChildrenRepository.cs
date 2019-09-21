using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IISportSchool.Models;

namespace IISportSchool.Models
{
    public class EFChildrenRepository : IChildrenRepository
    {
        private ApplicationDbContext _context;
        public EFChildrenRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Children> Children => _context.Childrens;

        public Children Add(Children child)
        {
            _context.Childrens.Add(child);
            _context.SaveChanges();
            return child;
        }

        public Children Delete(Children child)
        {
            _context.Childrens.Remove(child);
            _context.SaveChanges();
            return child;
        }

        public Children GetChildren(int id)
        {
            return _context.Childrens.SingleOrDefault(c => c.Id == id);
        }

        public Children Update(Children childChanges)
        {
            var child = _context.Childrens.Attach(childChanges);
            child.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return childChanges;
        }
    }
}
