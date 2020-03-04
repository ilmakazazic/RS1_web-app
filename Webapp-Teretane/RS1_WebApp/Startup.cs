using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using RS1_Teretana.EF;
using RS1_WebApp.Areas.Clanovi.QuartzNetHelper;
using Stripe;
using RS1_WebApp.Areas.Clanovi.SignalRChat.Hubs;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace RS1_WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment HostingEnvironment { get; }
        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            //Configuration = configuration;
            this.HostingEnvironment = hostingEnvironment;
            this.Configuration = configuration;
        }

        //public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<MyContext>(options =>
            //      options.UseSqlServer(@"Server=p1851dbserver.database.windows.net; Database=p1851_Db; Trusted_Connection=False; 
            //                            MultipleActiveResultSets=True; User ID=melisa; Password=MelSm123"));            
            services.AddDbContext<MyContext>(options =>
                  options.UseSqlServer(@"Server=app.fit.ba;Database=p1851;Trusted_Connection=False;MultipleActiveResultSets=true; 
                                        User ID=MelisaS; Password=e4$ct50R"));


            services.AddRazorPages();
            services.AddSignalR();
            services.AddQuartz(typeof(ScheduledJob));
            //3
            services.AddLogging();
            services.AddSingleton<IConfiguration>(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{this.HostingEnvironment.EnvironmentName.ToLower()}.json")
                .Build());
            //services.AddSingleton<IConfiguration>(new ConfigurationBuilder()
            //   .SetBasePath(Directory.GetCurrentDirectory())
            //   .AddJsonFile("appsettings.json")
            //   .AddJsonFile($"appsettings.{this.HostingEnvironment.EnvironmentName.ToLower()}.json")
            //   .Build());

            //services.Add(new ServiceDescriptor(typeof(IJob), typeof(ScheduledJob), ServiceLifetime.Transient));
            //services.AddSingleton<IJobFactory, ScheduledJobFactory>();
            //services.AddSingleton<IJobDetail>(provider =>
            //{
            //    return JobBuilder.Create<ScheduledJob>()
            //      .WithIdentity("Sample.job", "group1")
            //      .Build();
            //});

            //services.AddSingleton<ITrigger>(provider =>
            //{
            //    return TriggerBuilder.Create()
            //    .WithIdentity($"Sample.trigger", "group1")
            //    .StartNow()
            //    .WithSimpleSchedule
            //     (s =>
            //        s.WithInterval(TimeSpan.FromSeconds(5))
            //        .RepeatForever()
            //     )
            //     .Build();
            //});

            //services.AddSingleton<IScheduler>(provider =>
            //{
            //    var schedulerFactory = new StdSchedulerFactory();
            //    var scheduler = schedulerFactory.GetScheduler().Result;
            //    scheduler.JobFactory = provider.GetService<IJobFactory>();
            //    scheduler.Start();
            //    return scheduler;
            //});

            //THIS
            //services.AddDbContext<MyContext>();

            services.AddControllers();
            var scheduler = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();
            //services.AddSingleton(scheduler);
            //services.AddHostedService<QuartzHostedService>();

            ////var scheduler = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();
            //scheduler.JobFactory = new MyJobFactory(services.BuildServiceProvider());
            //services.AddSingleton(scheduler);


            //4
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<MyContext>()
            //    .AddDefaultTokenProviders();

            //services.Configure<IdentityOptions>(options =>
            //{
            //    //Password settings
            //    options.Password.RequireDigit = false;
            //    options.Password.RequiredLength = 6;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequiredUniqueChars = 0;

            //    // Lockout settings
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //    options.Lockout.MaxFailedAccessAttempts = 10;

            //    // User settings
            //    options.User.RequireUniqueEmail = true;
            //});

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/Login/Index";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Login/OdbijenPristup";
            });

            //// Make app full protect (Login&Registration only access)
            //var policy = new AuthorizationPolicyBuilder()
            //    .RequireAuthenticatedUser()
            //    .Build();

            //services.AddMvc(x => x.Filters.Add(new AuthorizeFilter(policy)));


            services.AddControllersWithViews();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddProgressiveWebApp();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            StripeConfiguration.SetApiKey(Configuration["Stripe:TestSecretKey"]);
            app.UseStaticFiles();
            //scheduler.ScheduleJob(app.ApplicationServices.GetService<IJobDetail>(), app.ApplicationServices.GetService<ITrigger>());
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseQuartz();
            app.UseMvc(routes =>
            {
                routes.MapAreaRoute(
                  name: "Uposlenici",
                  areaName: "Uposlenici",
                  template: "Uposlenici/{controller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                   name: "Clanovi",
                   areaName: "Clanovi",
                   template: "Clanovi/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");

            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapHub<ChatHub>("/chatHub");
            });

            var cultureInfo = new CultureInfo("en-US");
            cultureInfo.NumberFormat.CurrencySymbol = "€";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");

            //    endpoints.MapAreaControllerRoute(
            //        name: "Uposlenici",
            //        areaName: "Uposlenici",
            //        pattern: "Uposlenici/{controller=Home}/{action=Index}/{id?}");

            //    endpoints.MapAreaControllerRoute(
            //        name: "Clanovi",
            //        areaName: "Clanovi",
            //        pattern: "Clanovi/{controller=Home}/{action=Index}/{id?}");

            //});
        }
    }
}
