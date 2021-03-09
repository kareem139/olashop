using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using olashop.Data;
using olashop.Models;
using olashop.Stripedata;
//using Omu.AwesomeMvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace olashop
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 8;


            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders().AddRoles<IdentityRole>();
            services.AddControllersWithViews();
            //var p = new AweMetaProvider();
            services.AddMvc(option=> {
                
            }).AddNewtonsoftJson(); 
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);//We set Time here 
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => Cart.GetCart(sp));
            services.Configure<StripeSetting>(Configuration.GetSection("Stripe"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["SecretKey"]);
      
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
                  pattern: "{controller=FirstHome}/{action=FirstIndex}/{id?}"
                );
            });
        }
    }
}
