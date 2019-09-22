using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IISportSchool.Models;
using Microsoft.EntityFrameworkCore;

namespace IISportSchool.Controllers
{
    public class InfoController : Controller
    {
        ApplicationDbContext _context;
        List<SchoolService> services = new List<SchoolService>();
        List<Children> Childrens = new List<Children>();
        List<Worker> Workers = new List<Worker>();
        double Salaries = 0;
        double Profit = 0;
        InfoViewModel viewModel;
        public InfoController(ApplicationDbContext context)
        {
            _context = context;
            services.AddRange(_context.Departments
                .Include(s => s.Sections)
                    .ThenInclude(se => se.Groups)
                        .ThenInclude(g=>g.Childrens)
                .Include(s=>s.Sections)
                    .ThenInclude(se=>se.Teachers)
                    .ThenInclude(t=>t.Position)
                .ToList());
            foreach (var service in services)
            {
                Workers.AddRange(service.GetStaff());
                Childrens.AddRange(service.GetAllChildren());
                Profit += service.GetServiceProfit();
            }
            foreach (var worker in Workers)
                Salaries += worker.Salary;
        }
        public IActionResult Index()
        {
            viewModel = new InfoViewModel
            {
                Childrens = Childrens,
                Workers = Workers,
                Profit = Profit,
                Salaries = Salaries
            };
            return View(viewModel);
        }
    }

}