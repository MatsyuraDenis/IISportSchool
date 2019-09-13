using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public interface IServiceRepository : IDepartmentDelete
    {
        void CreateDepartment();
        Department CreateDepartment(Department department);
        Department UpdateDepartment(Department department);
        Department DepartmentDetails(int? id);
        Department DepartmentList();
        Department AddSection(int departmentId=0);
        Department RemoveSection(int? id);
        Department DeleteSectionConfirmed(int? id);

    }
}
