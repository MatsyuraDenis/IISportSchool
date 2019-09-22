using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class EFPositionRepository : IPositionRepository
    {
        ApplicationDbContext _context;
        public EFPositionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Position> Positions => _context.Positions;

        public Position Add(string name)
        {
            Position position = new Position { Name = name };
            return Add(position);
        }

        public Position Add(Position position)
        {
            _context.Add(position);
            _context.SaveChanges();
            return position;
        }

        public Position Get(int id)
        {
            return _context.Positions.SingleOrDefault(p => p.Id == id);
        }

        public Position Get(string name)
        {
            return _context.Positions.SingleOrDefault(p => p.Name.ToLower() == name.ToLower());
        }
    }
}
