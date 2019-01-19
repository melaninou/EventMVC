using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(EventProject.Areas.Identity.IdentityHostingStartup))]
namespace EventProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}