using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class InfoViewModel
    {
        public IEnumerable<Children> Childrens { get; set; }
        public IEnumerable<Worker> Workers { get; set; }
        public double Profit { get; set; }
        public double Salaries { get; set; }
    }
}
