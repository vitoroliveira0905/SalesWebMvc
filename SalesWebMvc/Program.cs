﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMvc.Data;
using System.Configuration;
namespace SalesWebMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionStr = "server=localhost;userid=developer;password=1234567;database=saleswebmvcappdb";
            builder.Services.AddDbContext<SalesWebMvcContext>(options =>
                options.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr)));

            // Add services to the container.
            builder.Services.AddScoped<SeedingService>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();

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
