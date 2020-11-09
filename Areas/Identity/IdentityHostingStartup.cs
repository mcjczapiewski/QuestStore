using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(QuestStore.Areas.Identity.IdentityHostingStartup))]
namespace QuestStore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}