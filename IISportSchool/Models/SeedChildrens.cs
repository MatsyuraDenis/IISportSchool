using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class SeedChildrens
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Childrens.Any())
            {
                context.Childrens.AddRange(
                new Children
                {
                    Name = "Андрій",
                    SecondName = "Дружко",
                    Age = 12
                },
                new Children
                {
                    Name = "Антон",
                    SecondName = "Колішко",
                    Age = 13
                },               
                new Children
                {
                    Name = "Святослав",
                    SecondName = "Рюрик",
                    Age = 14
                },
                new Children
                {
                    Name = "Богуслав",
                    SecondName = "Мурик",
                    Age = 11
                },  
                new Children
                {
                    Name = "Антоніна",
                    SecondName = "Маур",
                    Age = 7
                },
                new Children
                {
                    Name = "Богуслава",
                    SecondName = "Закар",
                    Age = 8
                },
                new Children
                {
                    Name = "Петро",
                    SecondName = "Іванов",
                    Age = 7
                }, 
                new Children
                {
                    Name = "Артем",
                    SecondName = "Безайло",
                    Age = 17
                },
                new Children
                {
                    Name = "Василь",
                    SecondName = "Михайлов",
                    Age = 18
                }
                );
                context.SaveChanges();
            }
        }
    }
}
