using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public abstract class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Salary { get; set; }
        public int YearsOfExperience { get; set; }
        public Position Position { get; set; }
        public string PhotoPath { get; set; }
    }
}
