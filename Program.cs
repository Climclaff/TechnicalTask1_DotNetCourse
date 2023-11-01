using Microsoft.EntityFrameworkCore;
using TechnicalTask1_DotNetCourse.Data;

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

            var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            { 
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}