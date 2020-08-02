using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SA.Models;

namespace SA
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration["ConnectionString"];
        }

        public static String ConnectionString;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddLocalization(opts => opts.ResourcesPath = "Resources"); //kroz action koji ce biti direktorijum sa resursom

            //*
            services.AddIdentity<AplicationUser, IdentityRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<SAContext>()
                .AddDefaultTokenProviders();

            services.AddMvc()
                .AddDataAnnotationsLocalization(opts =>
                {
                    opts.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(Resource));
                });
            
            services.Configure<RequestLocalizationOptions>(
                opts =>
                {
                    var supported = new[]
                    {
                        new CultureInfo("en"),
                        new CultureInfo("de-DE"),
                        new CultureInfo("sr")
                    };
                    opts.DefaultRequestCulture = new RequestCulture(culture:"en",uiCulture:"en-US");
                    opts.SupportedCultures = supported;
                    opts.SupportedUICultures = supported;
                }
                );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }   
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRequestLocalization();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "details",
                //    template: "CarDetails",
                //    defaults: new
                //    {
                //        controller = "Home",
                //        action = "CarDetails"
                //    });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseCookiePolicy();
        }
    }
}
