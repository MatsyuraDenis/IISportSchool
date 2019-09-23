using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public static class StringHelpre
    {
        public static string FixName(this string name)
        {
            List<int> indexes = new List<int>();
            int i = 0;
            foreach(var letter in name)
            {
                if (char.IsUpper(letter))
                    indexes.Add(i);

                i++;
            }

            for(int j = 0; j < indexes.Count(); j++)
            {
                name.Insert(indexes[j]+j, " ");
            }

            name.ToLower();
            return name;
        }
    }
}
