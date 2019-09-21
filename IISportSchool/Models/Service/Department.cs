using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class Department : SchoolService
    {
        public List<Section> Sections { get; set; }
        public Employee ResponsivePerson { get; }

        public void AddSection(Section section)
        {
            Sections.Add(section);
        }

        public override List<Children> GetAllChildren()
        {
            List<Children> childrens = new List<Children>();
            foreach (var section in Sections)
            {
                childrens.AddRange(section.GetAllChildren());
            }
            return childrens;
        }

        public override int GetNumberOfChildren()
        {
            int num = 0;
            foreach (var section in Sections)
            {
                num += section.GetNumberOfChildren();
            }
            return num;
        }

        public override double GetServiceProfit()
        {
            double profit = 0;
            foreach (var section in Sections)
            {
                profit += section.GetServiceProfit();
            }
            return profit;
        }

        public override List<Worker> GetStaff()
        {
            List<Worker> workers = new List<Worker>();
            foreach (var section in Sections)
            {
                workers.AddRange(section.GetStaff());
            }
            return workers;
        }

        public void RemoveSection(Section section)
        {
            Sections.Remove(section);
        }
    }
}
