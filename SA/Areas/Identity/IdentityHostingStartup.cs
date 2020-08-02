using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SA.Models;

[assembly: HostingStartup(typeof(SA.Areas.Identity.IdentityHostingStartup))]
namespace SA.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SAContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SAContextConnection")));
            });
        }
    }
}