using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3
{
    public class Startup
    {
        private readonly IConfiguration _configuration1;
        public Startup(IConfiguration configuration)
        {
            _configuration1 = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options =>
            options.UseMySql(_configuration1.GetConnectionString("MySqlConnection")));
            services.AddMvc();
            services.AddScoped<IStudentRepository, SqlStudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions pageOptions = new DeveloperExceptionPageOptions();
                pageOptions.SourceCodeLineCount = 10;
                app.UseDeveloperExceptionPage(pageOptions);
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //处理404
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            //添加默认文件中间件
            // app.UseDefaultFiles(new DefaultFilesOptions
            //  {
            //  DefaultFileNames = new List<string> { "zzz.html" }
            //   });
            //添加静态文件
            app.UseStaticFiles();
            app.UseMvc();
            app.UseMvcWithDefaultRoute();
            //
            /*
                        app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaults",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
             
             */


        }
    }
}
