using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Core.Interfaces;
using FridgeWarehouse.Domain.Interfaces;

namespace FridgeWarehouse.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            /*
            builder.Services.AddHttpClient<FixturesViewComponent>(options =>
                 {
                     options.BaseAddress = new Uri("http://80.350.485.118/api/v2");
                 });
            */
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IJsonSerializeService<BaseDTO>, JsonSerializeService<BaseDTO>>();
            builder.Services.AddScoped<IJsonSerializeService<FridgeDTO>, JsonSerializeService<FridgeDTO>>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
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