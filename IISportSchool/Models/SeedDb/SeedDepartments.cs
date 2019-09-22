using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public static class SeedDepartments
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext _context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            _context.Database.Migrate();
            if (!_context.Departments.Any())
            {
                _context.Departments.AddRange(
                    new Department
                    {
                        Name = DefaultSectionName.Sport,
                        ImagePath = @"~/images/departmentLogos/sport.jpg"
                    },
                    new Department
                    {
                        Name = DefaultSectionName.Dance,
                        ImagePath = @"~/images/departmentLogos/dance.jpg"
                    }
                    );
                _context.SaveChanges();
            }
        }
    }
}
