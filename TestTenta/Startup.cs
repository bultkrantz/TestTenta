using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTenta.Data;
using TestTenta.Models;
using TestTenta.Services;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Logging;

namespace TestTenta
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
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("DefaultConnection"));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ILoggerFactory, LoggerFactory>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }            

            app.UseStaticFiles();

            app.UseAuthentication();

            AddTestData(context);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }


        private static void AddTestData(ApplicationDbContext context)
        {
            var tv = new ProductCategory
            {
                Name = "TV"
            };
            var dvd = new ProductCategory
            {
                Name = "DVD"
            };
            var vhs = new ProductCategory
            {
                Name = "VHS"
            };
            context.Categories.AddRange(tv, dvd, vhs);

            context.SaveChanges();
        }
    }
}
