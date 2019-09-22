using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class AddChildViewModel
    {
        public Children Children { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
    }
}
