using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class PositionFactory : IPositionFactory
    {
        Hashtable positions = new Hashtable();
        IPositionRepository _repository;

        public PositionFactory(IPositionRepository repository)
        {
            _repository = repository;
            foreach (var position in _repository.Positions)
                positions.Add(position.Name.ToLower(), position);
        }
        public Position GetPosition(string name)
        {
            var position = positions[name.ToLower()] as Position;
            if (position == null)
            {
                Position position1 = new Position
                {
                    Name = name
                };
                _repository.Add(position1);
            }
                

            return position;
        }
    }
}
