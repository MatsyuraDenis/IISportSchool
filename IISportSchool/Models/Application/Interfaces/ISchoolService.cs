using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models.Application.Interfaces
{
    public interface ISchoolService
    {

        int GetNumberOfChildren();
        double GetServiceProfit();
        List<Worker> GetStaff();
        List<Children> GetAllChildren();
    }
}
