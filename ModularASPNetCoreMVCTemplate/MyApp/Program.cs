using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModularASPNetCoreMVCTemplate.Extensions;
using MyApp.Data.Database;
using MyApp.Data.DataModels;

namespace ModularASPNetCoreMVCTemplate;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder
            .AddEnvironmentVariablesConfig()
            .Services
            .AddDbContext(builder.Configuration)
            .AddIdentity()
            .AddControllersWithViewsService(builder.Environment)
            .AddCookiePolicy()
            .AddApplicationServices()
            .AddDeveloperPageException(builder.Environment);




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