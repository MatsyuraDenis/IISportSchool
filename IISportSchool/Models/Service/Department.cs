using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class Department : SchoolService
    {
        public List<Section> Sections { get; }
        public Employee ResponsivePerson { get; }

        public override int NumberOfChildren
        {
            get
            {
                int num = 0;
                foreach(var section in Sections)
                {
                    num += section.NumberOfChildren;
                }
                return num;
            }
        }

        public void AddSection(Section section)
        {
            Sections.Add(section);
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
