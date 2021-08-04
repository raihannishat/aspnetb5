


using System;
using Autofac;
using System.Reflection;
using TicketBookingSystem.Booking;
using Microsoft.Extensions.Hosting;
using TicketBookingSystem.Web.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TicketBookingSystem.Booking.Contexts;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace TicketBookingSystem.Web
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();

            WebHostEnvironment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }
        public static ILifetimeScope AutofacContainer { get; set; }

        public void ConfigureContainer(ContainerBuilder container)
        {
            var connection = GetConnectionStringAndAssembly();
            container.RegisterModule(new BookingModule(connection.connectionString,
                connection.migrationAssembly));
        }

        private (string connectionString, string migrationAssembly) GetConnectionStringAndAssembly()
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationAssembly = Assembly.GetExecutingAssembly().GetName().FullName;
            return (connectionString, migrationAssembly);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = GetConnectionStringAndAssembly();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection.connectionString));

            services.AddDbContext<BookingDbContext>(options =>
                options.UseSqlServer(connection.connectionString,
                m => m.MigrationsAssembly(connection.migrationAssembly)));

            services.AddDefaultIdentity<IdentityUser>(options => 
                options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Signin";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(100);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews(); 
            services.AddHttpContextAccessor(); 
            services.AddRazorPages(); 
            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Dashboard}/{action=Home}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=admin}/{controller=Dashboard}/{action=Home}/{id?}"
                );

                endpoints.MapRazorPages();
            });
        }
    }
}
