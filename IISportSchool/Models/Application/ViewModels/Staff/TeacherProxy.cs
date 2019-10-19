using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class TeacherProxy : ITeacherInfo
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }

        public string FullName { get; private set; }

        public string SectionName { get; private set; }
        public string PhotoPath { get; set; }
        private Teacher _teacher;

        public string ShortInfo()
        {
            return string.Format("{0}, тренер секції '{1}'", FullName, SectionName);
        }
        public TeacherProxy() { }
        public TeacherProxy(Teacher teacher)
        {
            FullName = string.Format("{0} {1}", teacher.Name, teacher.SecondName);
            SectionName = teacher.SectionName;
            TeacherId = teacher.Id;
            PhotoPath = teacher.PhotoPath;
        }

        public static TeacherProxy Create(Teacher teacher)
        {
            return new TeacherProxy(teacher);
        }
        public void AddTeacher(Teacher teacher)
        {
            FullName = string.Format("{0} {1}", teacher.Name, teacher.SecondName);
            SectionName = teacher.SecondName;
            TeacherId = teacher.Id;
        }
        public Teacher LoadTeacher(ITeacherRepository repo)
        {
            _teacher = repo.Teachers.SingleOrDefault(t => t.Id == TeacherId);
            return _teacher;
        }
    }
}
