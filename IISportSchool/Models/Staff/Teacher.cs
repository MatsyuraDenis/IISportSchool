using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class Teacher : Worker, ITeacherInfo
    {
        public string FullName => string.Format("{0} {1}", SecondName, Name);
        public virtual Group Group { get; set; }
        public int? GroupId { get; set; }
        public virtual Section Section { get; set; }
        public int SectionId { get; set; }

        public string SectionName { get; private set; }
        public Teacher() { }
        public Teacher(string name, string secondName, int salary, int yearOfExperiance, string sectionName) 
        {
            Name = name;
            SecondName = sectionName;
            Salary = salary;
            YearsOfExperience = yearOfExperiance;
            SecondName = sectionName;
            SectionName = Section.Name;
        }

        public string ShortInfo()
        {
            return string.Format("{0}, тренер секції {1}", FullName, SectionName);
        }

        public void SetSectionName(string name)
        {
            SectionName = name;
        }
    }
}
