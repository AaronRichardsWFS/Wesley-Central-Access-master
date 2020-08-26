using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WCAProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Server.IIS;

namespace WCAProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        
            services.Configure<IISServerOptions>(options => {
                options.AutomaticAuthentication = true;
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddAuthentication(IISServerDefaults.AuthenticationScheme);
            services.AddAuthorization(options => {
                if (Environment.IsDevelopment())
                {
                    options.AddPolicy("WFS_Admins", policy => policy.RequireAssertion(ctx => true));
                    options.AddPolicy("WFS_Managers", policy => policy.RequireAssertion(ctx => true));
                    options.AddPolicy("WFS_Users", policy => policy.RequireAssertion(ctx => true));
                }
                else {
                    options.AddPolicy("WFS_Admins", policy => policy.RequireRole(Configuration["SecuritySettings:WFS_Admins"]));
                    options.AddPolicy("WFS_Managers", policy => policy.RequireRole(Configuration["SecuritySettings:WFS_Admins"], Configuration["SecuritySettings:WFS_Managers"]));
                    options.AddPolicy("WFS_Users", policy => policy.RequireRole(Configuration["SecuritySettings:WFS_Admins"], Configuration["SecuritySettings:WFS_Managers"], Configuration["SecuritySettings:WFS_Users"]));
                }
                // options.DefaultPolicy = new AuthorizationPolicyBuilder(
                //     IISServerDefaults.AuthenticationScheme
                // ).RequireAuthenticatedUser().Build();
            });
            
            services.AddDbContext<WCAProjectContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("WCAProjectContext");
                    options.UseSqlServer(connectionString);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Home/Error");
            }
            else
            {
                // app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/Home/Exception");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/Home/Error/", "?statusCode={0}");
            app.UseRouting();
            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
