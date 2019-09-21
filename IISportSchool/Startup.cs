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
            services.AddScoped<ITeacherRepository, EFTeacherRepository>();
            services.AddScoped<IChildrenRepository, EFChildrenRepository>();
            services.AddScoped<IServiceRepository, EFServiceRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<AbstractDepartmentDeleter, DepartmentDeleter>();
            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<Section>, SectionValidator>();
            services.AddTransient<IValidator<Department>, DepartmentValidator>();
            services.AddTransient<IValidator<Group>, GroupValidation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseMvc(routes =>
            {
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
        }
    }
}
