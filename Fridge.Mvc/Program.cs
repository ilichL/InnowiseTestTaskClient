using AutoMapper;
using FridgeWarehouse.Core.DTOs;
using FridgeWarehouse.Core.Interfaces;
using FridgeWarehouse.Data.Entities;
using FridgeWarehouse.Domain.Interfaces;
using FridgeWarehouse.Mvc.Mapper;

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
            /*
            var configuration = new MapperConfiguration(ctf =>
            {
                ctf.CreateMap<Fridge, FridgeDTO>();
                ctf.AddProfile<SourceProfile>();
            });
            */
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddInMemoryCollection();


            builder.Services.AddHttpClient();
            builder.Services.AddScoped<IJsonSerializeService<BaseDTO>, JsonSerializeService<BaseDTO>>();
            builder.Services.AddScoped<IJsonSerializeService<FridgeDTO>, JsonSerializeService<FridgeDTO>>();
            builder.Services.AddScoped<IJsonSerializeService<FridgeProductDTO>,
                JsonSerializeService<FridgeProductDTO>>();
            builder.Services.AddScoped<IJsonSerializeService<ProductDTO>,
                JsonSerializeService<ProductDTO>>();
            //builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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