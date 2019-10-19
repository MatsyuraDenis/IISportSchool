using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    // Composite pattern
    public abstract class SchoolService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public abstract int GetNumberOfChildren();
        public abstract double GetServiceProfit();
        public abstract List<Worker> GetStaff();
        public abstract List<Children> GetAllChildren();
    }
}
