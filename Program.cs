using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WCAProject.Data;

namespace WCAProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .InitializeDatabase()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }

    public static class DatabaseExtensions
    {
        public static IHost InitializeDatabase(this IHost appHost)
        {
            using (var scope = appHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                IConfiguration config = services.GetRequiredService<IConfiguration>();
                IHostEnvironment env = services.GetService<IHostEnvironment>();
                WCAProjectContext db =  services.GetRequiredService<WCAProjectContext>();

                db.Database.EnsureCreated();
                db.Database.Migrate();
            }
            return appHost;
        }
    }
}
