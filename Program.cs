using Microsoft.EntityFrameworkCore;
using TechnicalTask1_DotNetCourse.Data;
using TechnicalTask1_DotNetCourse.Repository;
using TechnicalTask1_DotNetCourse.Repository.Interfaces;
using TechnicalTask1_DotNetCourse.Services;
using TechnicalTask1_DotNetCourse.Services.Interfaces;

namespace TechnicalTask1_DotNetCourse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("TechincalTaskDb");
            builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ICatalogRepository, CatalogRepository>();
            builder.Services.AddScoped<IDbFileRepository, DbFileRepository>();
            builder.Services.AddScoped<ICatalogService, CatalogService>();
            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            { 
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "RootCatalog",
                    pattern: "Catalog/Root",
                      defaults: new { controller = "Catalog", action = "Index", id = 1 });


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            



            app.Run();
        }
    }
}