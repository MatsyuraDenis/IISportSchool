using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class Group : SchoolService
    {
        public Teacher Teacher { get; set; }
        public virtual TeacherProxy TeacherProxy { get; set; }
        public int MinChildAge { get; set; }
        public int MaxChildAge { get; set; }
        public List<Children> Childrens { get; set; }
        public Section Section { get; set; }
        public int SectionId { get; set; }
        public int PricePerMonth { get; set; }

        public Group(string name, int minChildAge, int maxChildAge, int sectionId, int pricePerMonth)
        {
            Name = name;
            MinChildAge = minChildAge;
            MaxChildAge = maxChildAge;
            SectionId = sectionId;
            PricePerMonth = pricePerMonth;
        }

        public Group()
        {

        }

        public override List<Children> GetAllChildren()
        {
            return Childrens;
        }

        public override int GetNumberOfChildren()
        {
            return Childrens.Count();
        }

        public override double GetServiceProfit()
        {
            return PricePerMonth * GetNumberOfChildren();
        }

        public override List<Worker> GetStaff()
        {
            List<Worker> workers = new List<Worker>();
            if (Teacher != null)
                workers.Add(Teacher);
            return workers;
        }
    }
}
