using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public interface ITeacherRepository
    {
        IQueryable<Teacher> Teachers { get; }
        Teacher GetTeacher(int id);
        Teacher Add(Teacher teacher);
        Teacher Update(Teacher teacher);
        Teacher Delete(Teacher teacher);
        Teacher Delete(TeacherProxy proxy);
    }
}
