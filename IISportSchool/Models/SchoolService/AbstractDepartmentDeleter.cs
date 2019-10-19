using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public abstract class AbstractDepartmentDeleter : IDisposable
    {
        private List<Group> groups;
        private List<Section> sections;
        public void DeleteDepartment(int id)
        {
            sections = GetSections(id);
            DeleteGroups(GetGroups(sections));
            DeleteSections(sections);           
            Delete(id);
        }
        protected abstract void DeleteSections(List<Section> sections);
        protected abstract void DeleteGroups(List<Group> groups);
        protected abstract void Delete(int departmentId);
        protected abstract List<Section> GetSections(int departmentId);
        protected abstract List<Group> GetGroups(List<Section> sections);

        public abstract void Dispose();
    }
}
