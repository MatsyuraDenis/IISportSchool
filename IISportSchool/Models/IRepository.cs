using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll { get; }
        T Get(int id);
        T Add(T entity);
        T Delete(int id);
        T Update(T entity);
    }
}
