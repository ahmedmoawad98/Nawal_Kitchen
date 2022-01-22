using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nawal_Kitchen.Data;

[assembly: HostingStartup(typeof(Nawal_Kitchen.Areas.Identity.IdentityHostingStartup))]
namespace Nawal_Kitchen.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Nawal_KitchenContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Nawal_KitchenContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Nawal_KitchenContext>();
            });
        }
    }
}