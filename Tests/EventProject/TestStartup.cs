using EventProject;
using EventProject.Data;
using Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.EventProject
{
    public class TestStartup :Startup
    {
        public const string Testing = "Testing";

        public TestStartup(IConfiguration configuration) : base(configuration) { }
        
        protected void setDatabase(IServiceCollection services)
        {
            var s =
                Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseInMemoryDatabase(s));
            services.AddDbContext<EventProjectDbContext>(
                options => options.UseInMemoryDatabase(s));
            
        }

        protected void setAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = "Test Scheme";
                options.DefaultChallengeScheme = "Test Scheme";
            }).AddTestAuth(o => { });
        }

        protected void setMvcWithAntiForgeryToken(IServiceCollection services)
        {
            services.AddMvc(options => options.Filters.Add(new AntiForgeryAttributeTests()));
        }

        protected void setErrorPage(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
        }
    }
}
