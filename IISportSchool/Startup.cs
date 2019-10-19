using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using IISportSchool.Models;
using IISportSchool.Models.FluentValidators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IISportSchool
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IConfiguration conf)
        {
            configuration = conf;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<ITeacherRepository, EFTeacherRepository>();
            services.AddScoped<IServiceRepository, EFServiceRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IPositionRepository, EFPositionRepository>();
            services.AddScoped<AbstractDepartmentDeleter, DepartmentDeleter>();
            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<Section>, SectionValidator>();
            services.AddTransient<IValidator<Department>, DepartmentValidator>();
            services.AddTransient<IValidator<Group>, GroupValidation>();
            services.AddTransient<IValidator<AddChildViewModel>, ChildrenValidator>();
            services.AddTransient<IValidator<Teacher>, TeacherValidator>();
            services.AddTransient<IValidator<TeacherViewModel>, TeacherViewModelValidator>();
            services.AddTransient<IValidator<UpdateteacherViewModel>, UpdateTeacherViewModelValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseDeveloperExceptionPage();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "Group-for-{sectionName}-section",
                    defaults: new { controller = "Group", action = "Create", sectionName = "" }
                );
                routes.MapRoute(
                    name: null,
                    template: "Group-details/{id}",
                    defaults: new { controller = "Group", action = "Details", id = 1 }
                );
                routes.MapRoute(
                    name: null,
                    template: "Section/{id}",
                    defaults: new { controller = "Service", action = "SectionDetails", id = 1 }
                    );
                routes.MapRoute(
                    name: null,
                    template: "Section-edit/{id}",
                    defaults: new { controller = "Service", action = "UpdateSection", id = 1 }
                    );
                routes.MapRoute(
                    name: null,
                    template: "Home",
                    defaults: new { controller = "Home", action = "Index" }
                );
                routes.MapRoute(
                    name: null,
                    template: "Departments",
                    defaults: new { controller = "Service", action = "DepartmentList" }
                );
                routes.MapRoute(
                    name: null,
                    template: "Department/{id}",
                    defaults: new { controller = "Service", action = "DepartmentDetails", id = 1 }
                );
                routes.MapRoute(
                    name: null,
                    template: "Department-edit/{id}",
                    defaults: new { controller = "Service", action = "UpdateDepartment", id = 1 }
                );
                routes.MapRoute(
                    name: null,
                    template: "Department-new",
                    defaults: new { controller = "Service", action = "AddDepartment" }
                );

                routes.MapRoute(
                    name: null,
                    template: "SchoolInfo",
                    defaults: new { controller = "Info", action = "Index" }
                );
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Home", action = "Index" });
                routes.MapRoute(
                    name: null,
                    template: "{controller}",
                    defaults: new { controller = "Home", action = "Index" });
                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}",
                    defaults: new { controller = "Home", action = "Index" });
                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });

            ISeedDbAbstractFactory seedDb = new EFSeedDbAbstractFactory();

            app.ApplicationServices.GetRequiredService<ApplicationDbContext>().Database.Migrate();

            SeedAdmin.SeedRoles(roleManager);


            SeedAdmin.SeedUsers(userManager);


            seedDb.EnsurePopulated(app);
        }
    }


}
