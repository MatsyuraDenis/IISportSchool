using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public string ImagePath { get; set; }
        public string About { get; set; }
        public string SchoolName { get; set; }
        public string SchoolNameContinue { get; set; }
        public string StaffInfo { get; set; }
        public string StaffImage { get; set; }

        public void Initialize()
        {
            SchoolName = "Бзик";
            SchoolNameContinue = "це нові можливості для розвитку дитини";
            StaffInfo = "Хороший тренер сповнений ентузіазму і надихає на досягнення нових результатів."
                        + Environment.NewLine
                        + "Він ваш наставник, радник і друг, який підтримає і втішить при поразках."
                        + Environment.NewLine
                        + "Ми зібрали кращих тренерів нашої країни!";
            StaffImage = @"~/images/home/staff.jpg";
        }
    }
}
