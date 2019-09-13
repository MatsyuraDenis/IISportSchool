using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class EFServiceRepository : IServiceRepository
    {
        public Department AddSection(int departmentId = 0)
        {
            throw new NotImplementedException();
        }

        public void CreateDepartment()
        {
            throw new NotImplementedException();
        }

        public Department CreateDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Department department)
        {
            throw new NotImplementedException();
        }

        public void DeleteDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public void DeleteGroups(List<Group> groups)
        {
            throw new NotImplementedException();
        }

        public Department DeleteSectionConfirmed(int? id)
        {
            throw new NotImplementedException();
        }

        public void DeleteSections(List<Section> sections)
        {
            throw new NotImplementedException();
        }

        public Department DepartmentDetails(int? id)
        {
            throw new NotImplementedException();
        }

        public Department DepartmentList()
        {
            throw new NotImplementedException();
        }

        public Department RemoveSection(int? id)
        {
            throw new NotImplementedException();
        }

        public Department UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
