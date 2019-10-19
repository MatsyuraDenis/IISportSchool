using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class TeacherViewModel
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Salary { get; set; }
        public int YearsOfExperience { get; set; }
        public List<Section> Sections { get; set; }
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public IFormFile Photo { get; set; }
    }
}
