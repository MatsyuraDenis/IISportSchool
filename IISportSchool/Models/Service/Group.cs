using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class Group : SchoolService
    {
        public TeacherProxy Teacher { get; set; }
        public int MinChildAge { get; set; }
        public int MaxChildAge { get; set; }
        public List<Children> Childrens { get; set; }
        public Section Section { get; set; }
        public int SectionId { get; set; }
        public int PricePerMonth { get; set; }

        public override int NumberOfChildren => Childrens.Count();
        public override double GetServiceProfit()
        {
            return PricePerMonth * NumberOfChildren;
        }

        public override List<Worker> GetStaff()
        {
            List<Worker> workers = new List<Worker>();
            workers.Add(Teacher.LoadTeacher());
            return workers;
        }
    }
}
