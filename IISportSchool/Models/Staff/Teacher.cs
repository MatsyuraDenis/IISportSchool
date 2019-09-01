using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class Teacher : Worker, ITeacherInfo
    {
        public string FullName => string.Format("{0} {1}", Name, SecondName);
        public Group Group { get; set; }
        public int? GroupId { get; set; }

        public string SectionName { get; private set; }

        public Teacher() { }
        public Teacher(string name, string secondName, int salary, int yearOfExperiance, string sectionName) 
        {
            Name = name;
            SecondName = sectionName;
            Salary = salary;
            YearsOfExperience = yearOfExperiance;
            SecondName = sectionName;
        }
        public void ChangeSection(string sectionName)
        {
            SectionName = sectionName;
        }
        public void ChangeSection(Section section)
        {
            ChangeSection(section.Name);
        }
        public string CreateFullName()
        {
            return string.Format("{0} {1}", SecondName, Name);
        }

        public string ShortInfo()
        {
            return string.Format("{0}, тренер секції '{1}'", FullName, SectionName);
        }
    }
}
