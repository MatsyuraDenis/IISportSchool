﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class Section : SchoolService
    {
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public virtual List<Group> Groups { get; }
        public override int NumberOfChildren
        {
            get
            {
                int num = 0;
                foreach(var group in Groups)
                {
                    num += group.NumberOfChildren;
                }
                return num;
            }
        }



        public override double GetServiceProfit()
        {
            double profit = 0;
            foreach(var group in Groups)
            {
                profit += group.GetServiceProfit();
            }
            return profit;
        }

        public override List<Worker> GetStaff()
        {
            List<Worker> workers = new List<Worker>();
            foreach(var group in Groups)
            {
                workers.AddRange(group.GetStaff());
            }
            return workers;
        }

        public void AddGroup(Group group)
        {
            Groups.Add(group);
        }
        public void RemoveGroup(string name)
        {
            var group = Groups.SingleOrDefault(g => g.Name == name);
            Groups.Remove(group);   
        }
        public void RemoveGroup(int id)
        {
            var group = Groups.SingleOrDefault(g => g.Id == id);
            Groups.Remove(group);
        }
    }
}
