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
        public IQueryable<Children> Childrens => _context.Childrens;
    }
}
