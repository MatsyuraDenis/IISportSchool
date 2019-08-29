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
        public IEnumerable<Teacher> GetTeachers => _context.Teachers;
    }
}
