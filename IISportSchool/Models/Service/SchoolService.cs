using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public abstract class SchoolService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public abstract int NumberOfChildren { get; }

        public abstract double GetServiceProfit();
        public abstract List<Worker> GetStaff();

    }
}
