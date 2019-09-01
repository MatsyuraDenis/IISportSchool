using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public interface ITeacherInfo
    {
        string FullName { get; }
        string SectionName { get; }
        string ShortInfo();
    }
}
