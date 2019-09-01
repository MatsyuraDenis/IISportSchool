using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class TeacherProxy : ITeacherInfo
    {
        public int TeacherId { get; set; }

        public string FullName { get; }

        public string SectionName { get; private set; }
        private Teacher _teacher;

        public string ShortInfo()
        {
            return string.Format("{0}, тренер секції '{1}'", FullName, SectionName );
        }

        public TeacherProxy(Teacher teacher)
        {
            FullName = string.Format("{0} {1}", teacher.Name, teacher.SecondName);
            SectionName = teacher.SecondName;
            TeacherId = teacher.Id;
        }

        public static TeacherProxy Create(Teacher teacher)
        {
            return new TeacherProxy(teacher);
        }

        public Teacher LoadTeacher()
        {
            
            ApplicationDbContext context = new ApplicationDbContext();
            _teacher = context.Teachers.SingleOrDefault(t => t.Id == TeacherId);
            return _teacher;
        }
    }
}
