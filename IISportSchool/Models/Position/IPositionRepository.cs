using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public interface IPositionRepository
    {
        IQueryable<Position> Positions { get; }
        Position Get(int id);
        Position Get(string name);
        Position Add(string name);
        Position Add(Position position);
    }
}
