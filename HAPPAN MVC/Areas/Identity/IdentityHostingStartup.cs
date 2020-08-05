using System;
using HAPPAN_MVC.Areas.Identity.Data;
using HAPPAN_MVC.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(HAPPAN_MVC.Areas.Identity.IdentityHostingStartup))]
namespace HAPPAN_MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<HAPPANDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("HAPPAN_MVC_AuthDBContextConnection")));

                services.AddDefaultIdentity<User>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<HAPPANDBContext>();
            });
        }
    }
}