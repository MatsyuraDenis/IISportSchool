using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public interface IServiceRepository : IDisposable
    {
        void CreateDepartment(Department department);
        void UpdateDepartment(Department department);
        IQueryable<Department> Departments { get; }
        Department GetDepartment(int id);

        void CreateSection(Section section);
        void UpdateSection(Section section);
        void DeleteSection(Section section);
        IQueryable<Section> ListOfSections();
        Section GetSection(int id);
        Section GetSectionWithGroups(int id);
        Section GetSectionFull(int id);
        void Save();
    }
}
