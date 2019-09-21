using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public interface IGroupRepository : IDisposable
    {
        void Add(Group group);
        void Update(Group group);
        void Delete(Group group);
        Group Get(int id);
        IQueryable<Group> Groups { get; }
        void Save();
    }
}
