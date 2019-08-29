using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IISportSchool.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IISportSchool.Models;

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
            services.AddTransient<ITeacherRepository, EFTeacherRepository>();
            services.AddTransient<IChildrenRepository, EFChildrenRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}",
                    defaults: new { controller = "Children", action = "List" });
            });

            SeedChildrens.EnsurePopulated(app);
            SeedChildrens.EnsurePopulated(app);
        }
    }
}
