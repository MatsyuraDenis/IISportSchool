using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public interface IPositionStrategy
    {
        string CreatePosition(TeacherPositionList list);
        string CreatePosition(int number);
    }
}
