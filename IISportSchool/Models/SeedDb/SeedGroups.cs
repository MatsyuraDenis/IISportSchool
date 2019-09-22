using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class SeedGroups
    {
        public static void EnsurePopulated(IApplicationBuilder builder)
        {
            var _context = builder.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            _context.Database.Migrate();

            if (!_context.Groups.Any())
            {
                var footbal = _context.Sections.SingleOrDefault(s=>s.Name == "Футбол").Id;
                var basketboll = _context.Sections.SingleOrDefault(s=>s.Name == "Баскетбол").Id;
                var bycicle = _context.Sections.SingleOrDefault(s=>s.Name == "Велоспорт").Id;
                var hardAtl = _context.Sections.SingleOrDefault(s=>s.Name == "Важка атлетика").Id;
                var lightAtl = _context.Sections.SingleOrDefault(s=>s.Name == "Легка атлетика").Id;
                var tenis = _context.Sections.SingleOrDefault(s=>s.Name == "Настільний теніс").Id;
                var balet = _context.Sections.SingleOrDefault(s=>s.Name == "Балет").Id;
                var flamenko = _context.Sections.SingleOrDefault(s=>s.Name == "Фламенко").Id;
                List<Group> foot = new List<Group>();
                List<Group> bas = new List<Group>();
                List<Group> byc = new List<Group>();
                List<Group> ha = new List<Group>();
                List<Group> la = new List<Group>();
                List<Group> ten = new List<Group>();
                List<Group> bal = new List<Group>();
                List<Group> fla = new List<Group>();
                int k = 1;
                int jumper = 3;
                for(int i = 0; i < 5; i++)
                {
                    foot.Add(new Group(string.Format("{0}{1}{2}",k,i+1,footbal), jumper, jumper + 2, footbal, 200));
                    jumper += 3;
                }

                k = 2;
                jumper = 3;
                for (int i = 0; i < 5; i++)
                {
                    bas.Add(new Group(string.Format("{0}{1}{2}", k, i + 1, basketboll), jumper, jumper + 2, basketboll, 150));
                    jumper += 3;
                }

                k = 3;
                jumper = 3;
                for (int i = 0; i < 5; i++)
                {
                    byc.Add(new Group(string.Format("{0}{1}{2}", k, i + 1, bycicle), jumper, jumper + 2, bycicle, 250));
                    jumper += 3;
                }

                k = 4;
                jumper = 3;
                for (int i = 0; i < 5; i++)
                {
                    ha.Add(new Group(string.Format("{0}{1}{2}", k, i + 1, hardAtl), jumper, jumper + 2, hardAtl, 500));
                    jumper += 3;
                }

                k = 5;
                jumper = 3;
                for (int i = 0; i < 5; i++)
                {
                    la.Add(new Group(string.Format("{0}{1}{2}", k, i + 1, lightAtl), jumper, jumper + 2, lightAtl, 300));
                    jumper += 3;
                }

                k = 6;
                jumper = 3;
                for (int i = 0; i < 5; i++)
                {
                    ten.Add(new Group(string.Format("{0}{1}{2}", k, i + 1, tenis), jumper, jumper + 2, tenis, 120));
                    jumper += 3;
                }

                k = 7;
                jumper = 3;
                for (int i = 0; i < 5; i++)
                {
                    bal.Add(new Group(string.Format("{0}{1}{2}", k, i + 1, balet), jumper, jumper + 2, balet, 220));
                    jumper += 3;
                }

                k = 8;
                jumper = 3;
                for (int i = 0; i < 5; i++)
                {
                    fla.Add(new Group(string.Format("{0}{1}{2}", k, i + 1, flamenko), jumper, jumper + 2, flamenko, 225));
                    jumper += 3;
                }
                //foot, bas,byc,ha,la,ten,bal,fla
                _context.Groups.AddRange(foot);
                _context.Groups.AddRange(bas);
                _context.Groups.AddRange(byc);
                _context.Groups.AddRange(ha);
                _context.Groups.AddRange(la);
                _context.Groups.AddRange(ten);
                _context.Groups.AddRange(bal);
                _context.Groups.AddRange(fla);
                _context.SaveChanges();
            }
        }
    }
}
