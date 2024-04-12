using AutoMapper;
using Commons.Extensions;
using Commons.Identity.DummyData;
using Commons.Identity.Services;
using DAL.AutoMapper;
using DAL.Models.Admin;
using DAL.Repository;
using DAL.Repository.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinDef.Data;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinDef
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddDbContext<MinDefContext>(options =>
               options.UseLazyLoadingProxies()
                       .UseSqlServer(
                   Configuration.GetConnectionString("MinDef"),
                   x => x.MigrationsAssembly("DAL")));


            services.AddDistributedMemoryCache();
            services.AddCommonsLibraryViews();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(MinDefMapper));
            services.AddCommonsServices<Usuario, MinDefContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IContenedorTrabajo, ContenedorTrabajo>();
            services.AddScoped(typeof(IContenedorTrabajo<>), typeof(ContenedorTrabajo<>));
            services.AddSession();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = false;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddRazorPagesOptions(options =>
                {
                    options.AllowAreas = true;
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                }); 
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserService<Usuario> userService, MinDefContext context)
        {
            var adminUserResult = context.Users.Where(x => x.UserName == "jorgecutuli@gmail.com").ToList();

            foreach (Usuario a in adminUserResult)
            {
                DummyAdmin.SetAdmin(userService, a.UserName);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseSession();
            app.UseCommonsLibraryScripts();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
              );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseCookiePolicy();
        }
    }
}
