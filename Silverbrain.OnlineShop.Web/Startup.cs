using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Silverbrain.OnlineShop.Services;
using SilverBrain.OnlineShop.DataLayer;

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
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<OnlineShopDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<OnlineShopDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("OnlineShopContext"),
                x => x.MigrationsAssembly("Silverbrain.OnlineShop.DataLayer")));

            services.AddTransient<IAcountManagementService, AccountManagementServiceProvider>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async Task Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            await CreateRoles(services);
        }

        public async Task CreateRoles(IServiceProvider services)
        {
            var _roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var _userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            List<string> roles = new List<string> { "Admin" };

            foreach(string role in roles)
            {
                var roleExist = await _roleManager.RoleExistsAsync(role);
                if (!roleExist)
                    _roleManager.CreateAsync(new IdentityRole(role)).Wait();
            }

            var _adminUser = _userManager.FindByNameAsync("Admin");
            if(_adminUser == null)
            {
                //in oreder to change the manager username and password, change the value of ManagerUser
                //section in appsettings.json
                var adminUser = new ApplicationUser
                {
                    UserName = Configuration.GetSection("ManagerUser").GetValue<string>("UserName")
                };
                var creatResult = await _userManager.CreateAsync(adminUser, Configuration.GetSection("ManagerUser").GetValue<string>("Password"));

                if (creatResult.Succeeded)
                    await _userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
