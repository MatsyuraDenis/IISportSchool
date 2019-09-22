using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class UpdateteacherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Salary { get; set; }
        public int YearsOfExperience { get; set; }
        public int? GroupId { get; set; }
        public string SectionName { get; set; }
        public List<Group> Groups { get; set; }
        public IFormFile Photo { get; set; }
    }
}
