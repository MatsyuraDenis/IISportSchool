using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class EFSeedDbAbstractFactory : ISeedDbAbstractFactory
    {
        public void EnsurePopulated(IApplicationBuilder app)
        {
            SeedPositions.EnsurePopulated(app);
            SeedDepartments.EnsurePopulated(app);
            SeedSections.EnsurePopulated(app);
            SeedGroups.EnsurePopulated(app);
        }
    }
}
