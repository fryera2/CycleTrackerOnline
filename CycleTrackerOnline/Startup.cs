using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CycleTrackerOnline.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CycleTrackerOnline
{
    public class Startup
    {

        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        { 
            string connectionString = GetConnectionString();
            services.AddDbContext<CycleDbContext>(options => options.UseSqlServer(connectionString));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{Controller=Home}/{Action=Index}");
            });

        }

        private string GetConnectionString()
        {
            string connectionString;
            if (Convert.ToBoolean(_configuration.GetSection("AppSettings")["Debug"]))
            {
                connectionString = _configuration.GetConnectionString("DebugConnection");
            }
            else
            {
                connectionString = _configuration.GetConnectionString("DefaultConnection");
            }
            return connectionString;
        }
    }
}
