using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public interface IDepartmentDelete
    {
        void DeleteGroups(List<Group> groups);
        void DeleteSections(List<Section> sections);
        void DeleteDepartment(Department department);
        void Delete(int id);
        void Delete(Department department);
    }
}
