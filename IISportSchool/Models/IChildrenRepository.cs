using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public interface IChildrenRepository
    {
        IQueryable<Children> Childrens { get; }
    }
}
