using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class SeedSections
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext _context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            _context.Database.Migrate();

            if (!_context.Sections.Any())
            {
                var sportId = _context.Departments.SingleOrDefault(d => d.Name == DefaultSectionName.Sport).Id;
                var danceId = _context.Departments.SingleOrDefault(d => d.Name == DefaultSectionName.Dance).Id;
                _context.Sections.AddRange(
                    new Section
                    {
                        Name = "Футбол",
                        Description = "Футбол — це командний вид спорту, який грається між двома командами по одинадцять гравців зі сферичним м'ячем. Близько 250 мільйонів чоловіків і жінок із більш ніж 200 країн грають у футбол, що робить його найпопулярнішим в світі видом спорту. Футбол є олімпійським видом спорту.",
                        ImagePath = @"images/sections/football.png",
                        DepartmentId = sportId
                    },
                    new Section
                    {
                        Name = "Баскетбол",
                        Description = "Баскетбо́л — спортивна командна гра з м'ячем, який закидують руками в кільце із сіткою (кошик), закріпленою на щиті на висоті 3 метри 5 сантиметрів (10 футів) над майданчиком. Баскетбол є олімпійським видом спорту.",
                        ImagePath = @"images/sections/basketball.png",
                        DepartmentId = sportId
                    },
                    new Section
                    {
                        Name = "Велоспорт",
                        Description = "Велосипедний спорт — (в широкому сенсі слова) — це переміщення по землі з використанням транспортних засобів (велосипедів), які урухомлює м'язова сила людини. Велоспорт — одна з популярних форм рухомої активності, зміцнює легені та серце і звичайно, м'язи ніг.",
                        ImagePath = @"images/sections/bycicle.png",
                        DepartmentId = sportId
                    },
                    new Section
                    {
                        Name = "Важка атлетика",
                        Description = "Важка атлетика — силовий вид спорту у сучасних Олімпійських іграх, у якому атлет робить спробу підняття якомога більшої ваги штангу (грифу та важкоатлетичних дисків різної ваги). У сучасних Олімпійських іграх змагання з важкої атлетики включають в себе дві вправи — ривок а також поштовх та жим.",
                        ImagePath = @"images/sections/hardAtletic.png",
                        DepartmentId = sportId
                    },
                    new Section
                    {
                        Name = "Легка атлетика",
                        Description = "Легка́ атле́тика  — олімпійський вид спорту, який об'єднує спортивні дисципліни, що включають змагання з бігу, стрибків, метань та спортивної ходьби. Найбільш розповсюдженими видами легкої атлетики є бігові та технічні дисципліни на стадіоні, біг по шосе, крос та спортивна ходьба.",
                        ImagePath = @"images/sections/lightAtletic.png",
                        DepartmentId = sportId
                    },
                    new Section
                    {
                        Name = "Настільний теніс",
                        Description = "Настільний теніс — олімпійський вид спорту у якому використовують спеціальні ракетки та ігровий стіл, розмежований сіткою навпіл. Гра може проходити між двома суперниками або двома парами суперників. Завданням гравців є утримувати м'яч в грі за допомогою ракеток — кожен гравець після одного відскоку м'яча на своїй половині столу повинен відправити м'яч на половину столу суперника. Очко нараховується гравцеві, коли суперник не може повернути м'яч відповідно до правил. За сучасними міжнародними правилами, кожна партія триває до 11 очок. Матч складається з непарної кількості партій, і грається на більшість перемог у партіях.",
                        ImagePath = @"images/sections/ping-pong.png",
                        DepartmentId = sportId
                    },
                    new Section
                    {
                        Name = "Балет",
                        Description = "Балет (італ. ballare — танцювати) — вид сценічного мистецтва, танцювальна театральна вистава, у якій музика поряд з танцем відіграє важливу роль у розвитку сюжету і створенні відповідного настрою; синтетичний вид сценічного мистецтва, в якому зміст вистави розкривається в основному засобами танцю, міміки і музики. Джерела виникнення балетного жанру закладені в народних іграх, хороводах, сюжетних танцях тощо.",
                        ImagePath = @"images/sections/balet.png",
                        DepartmentId = danceId
                    },
                    new Section
                    {
                        Name = "Фламенко",
                        Description = "Фламенко — південноіспанський музичний, пісенний і танцювальний стиль, який склався в Андалусії наприкінці 18го сторіччя (перша згадка в літературі - 1774 рік). Спів і танець сольні, супроводжуються грою на гітарі, кастаньєтах.",
                        ImagePath = @"images/sections/flamenko.png",
                        DepartmentId = danceId
                    }
                    );
                _context.SaveChanges();
            }
        }
    }
}
