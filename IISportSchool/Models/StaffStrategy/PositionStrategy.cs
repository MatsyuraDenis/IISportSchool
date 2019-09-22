using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class PositionStrategy : IPositionStrategy
    {
        public string CreatePosition(TeacherPositionList name)
        {
            string name2 = name.ToString().FixName();
            string name1 = string.Format("Тренер з {0}", name.ToString().FixName());
            return name1;
        }

        public string CreatePosition(int number)
        {
            TeacherPositionList list = (TeacherPositionList)number;
            return CreatePosition(list);
        }
    }
}
