using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public static class SeedTeachers
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Teachers.Any())
            {
                context.Teachers.AddRange(
                    new Teacher
                    {
                        Name = "Петро",
                        SecondName = "Горбаньов",
                        Salary = 1200,
                        YearsOfExperience = 8
                    },
                    new Teacher
                    {
                        Name = "Максим",
                        SecondName = "Муранов",
                        Salary = 1000,
                        YearsOfExperience = 6
                    },                    
                    new Teacher
                    {
                        Name = "Станіслав",
                        SecondName = "Боровко",
                        Salary = 800,
                        YearsOfExperience = 3
                    },
                    new Teacher
                    {
                        Name = "Наталья",
                        SecondName = "Азі",
                        Salary = 1000,
                        YearsOfExperience = 7
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
