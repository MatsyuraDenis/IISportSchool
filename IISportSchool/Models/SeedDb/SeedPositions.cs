using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IISportSchool.Models
{
    public static class SeedPositions
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext _context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            _context.Database.Migrate();

            if (!_context.Positions.Any())
            {
                _context.Positions.AddRange(
                    new Position { Name = "Тренер"},
                    new Position { Name = "Директор"},
                    new Position { Name = "Бухгалтер" });
                _context.SaveChanges();
            }
        }
    }
}
