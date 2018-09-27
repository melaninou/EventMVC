using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventProject.Data;
using Infra;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


       /* public void ConfigureServices(IServiceCollection services)
        {
            setDatabase(services);
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            setAuthentication(services);
            services.AddTransient<IEmailSender, EmailSender>();
            setMvcWithAntyFoggeryToken(services);
           // services.AddScoped<ICountryObjectsRepository, CountryObjectsRepository>();
        }

        protected virtual void setMvcWithAntyFoggeryToken(IServiceCollection services) { services.AddMvc(); }

        protected virtual void setAuthentication(IServiceCollection services) { }
        protected virtual void setDatabase(IServiceCollection services)
        {
            var s = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(s));
            services.AddDbContext<EventProjectDbContext>(
                options => options.UseSqlServer(s));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            setErrorPage(app, env);
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute(name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        protected virtual void setErrorPage(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else { app.UseExceptionHandler("/Home/Error"); }
        }
    }*/
    
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
