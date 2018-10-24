﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SuvaLines.Models;

namespace SuvaLines
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //var connection = @"Server=WIN-9IHPL51LCPT\SQLEXPRESS,2301;Database=NewsLines;User ID=sa;Password=p@sw0rd;Trusted_Connection=True;ConnectRetryCount=0;Integrated Security=false";
            //services.AddDbContext<NewsLinesContext>(options => options.UseSqlServer(connection));



            //Replace connection string token
            var connStr = Configuration.GetConnectionString("DefaultConnection");
            if (connStr.Contains("%CONTENTROOTPATH%"))
                connStr = connStr.Replace("%CONTENTROOTPATH%", Environment.CurrentDirectory);

            //Set conection string
            //services.AddDbContext<NewsLinesContext>(options =>
            //    options.UseSqlServer(connStr));

            services.AddDbContext<SuvaLinesLocalContext>(options =>
                options.UseSqlServer(connStr));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
