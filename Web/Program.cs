using Microsoft.EntityFrameworkCore;
using Web.DataAccess;

namespace Web
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var builder = WebApplication.CreateBuilder(args);

         builder.Services.AddControllersWithViews();
         builder.Services.AddDbContext<DataContext>(config =>
         {
            config.UseSqlite("Data Source=Database.db");
         });

         var app = builder.Build();

         if (!app.Environment.IsDevelopment())
         {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
         }
         app.UseHttpsRedirection();
         app.UseStaticFiles();
         app.UseRouting();
         app.UseAuthorization();
         app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
         app.Run();
      }
   }
}