using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Silverbrain.OnlineShop.DataLayer;
using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.Mapping;
using Silverbrain.OnlineShop.Services;
using Silverbrain.OnlineShop.ViewModels.Settings;
using Silverbrain.OnlineShop.Web.Infrastructure;
using System;

namespace Silverbrain.OnlineShop.Web
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
            services.Configure<SiteSettings>(options => Configuration.Bind(options));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<OnlineShopDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<OnlineShopDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("OnlineShopContext"),
                x => x.MigrationsAssembly("Silverbrain.OnlineShop.DataLayer")));
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Account/Login";
                options.Cookie.MaxAge = TimeSpan.FromDays(1);
            });
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddKendo();
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
            services.AddCustomServices();

            services.AddAutoMapper(typeof(MappingProfile));

            services
               .AddControllersWithViews()
               .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                //scope.ServiceProvider.GetRequiredService<OnlineShopDbContext>().Database.Migrate();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseMiddleware<ContentGenerator>();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "default",
                    areaName: "Dashboard",
                    pattern: "{controller=Brand}/{action=Index}/{id?}");
            });

            app.UseCookiePolicy();

            app.AddUserWithRoles(services, Configuration).Wait();
            //CreateRoles(services).Wait();
        }
    }
}