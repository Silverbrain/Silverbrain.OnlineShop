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
using Silverbrain.OnlineShop.DataLayer;
using Silverbrain.OnlineShop.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;

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

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.MaxFailedAccessAttempts = 3;

                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.Cookie.MaxAge = TimeSpan.FromDays(1);
            });

            services.AddAuthentication();
            services.AddAuthorization();

            services.AddKendo();

            services.AddCustomServices();

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
                scope.ServiceProvider.GetRequiredService<OnlineShopDbContext>().Database.Migrate();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ContentGenerator>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseCookiePolicy();

            CreateRoles(services).Wait();
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

            var _adminUser = await _userManager.FindByNameAsync("Admin");
            if(_adminUser == null)
            {
                //in oreder to change the manager username and password, change the value of ManagerUser
                //section in appsettings.json
                var adminUser = new ApplicationUser
                {
                    UserName = Configuration.GetSection("ManagerUser").GetValue<string>("UserName"),
                    Email = Configuration.GetSection("ManagerUser").GetValue<string>("Email")
                };
                var creatResult = await _userManager.CreateAsync(adminUser, Configuration.GetSection("ManagerUser").GetValue<string>("Password"));

                if (creatResult.Succeeded)
                    await _userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
