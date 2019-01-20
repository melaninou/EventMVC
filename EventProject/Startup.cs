using Core;
using Domain.Attending;
using Domain.Comment;
using Domain.CommentProfile;
using Domain.Event;
using Domain.Profile;
using EventProject.Data;
using EventProject.Hubs;
using Infra;
using Infra.Attending;
using Infra.Comment;
using Infra.Event;
using Infra.Profile;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var s = Configuration.GetConnectionString("DefaultConnection");
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Event;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddDbContext<EventProjectDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Event;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IProfileObjectsRepository, ProfileObjectsRepository>();
            services.AddScoped<IEventObjectsRepository, EventObjectsRepository>();
            services.AddScoped<IAttendingObjectsRepository, AttendingRepository>();
            services.AddScoped<ICommentObjectsRepository, CommentRepository>();
            services.AddScoped<ICommentEventObjectsRepository, CommentEventRepository>();
            services.AddScoped<ICommentProfileObjectsRepository, CommentProfileRepository>();

            services.AddTransient<IImageHandler, ImageHandler>();
            services.AddTransient<IImageWriter, ImageWriter>();

            services.AddSignalR();
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

            app.UseSignalR(routes =>
            {
                routes.MapHub<CalendarHub>("/calendarHub");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
