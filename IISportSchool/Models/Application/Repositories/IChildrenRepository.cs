using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public interface IChildrenRepository
    {
        IQueryable<Children> Children { get; }
        Children GetChildren(int id);
        Children Add(Children child);
        Children Delete(Children child);
        Children Update(Children child);
    }
}
