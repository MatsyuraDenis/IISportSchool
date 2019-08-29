using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Salary { get; set; }
        public int YearsOfExperience { get; set; }
    }
}
