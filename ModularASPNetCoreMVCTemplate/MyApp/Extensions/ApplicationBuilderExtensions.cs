using Microsoft.EntityFrameworkCore;
using MyApp.Data.Database;

namespace ModularASPNetCoreMVCTemplate.Extensions;

public static class ApplicationBuilderExtensions
{
    public static WebApplication ApplyMigrations(this WebApplication app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.Migrate();
            }
        }
        return app;
    }

    public static WebApplication UseDeveloperExceptionPageMiddleware(this WebApplication app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        return app;
    }

    public static WebApplication UseExceptionHandlerMiddleware(this WebApplication app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        return app;
    }

    public static WebApplication UseSecureConnectionMiddleware(this WebApplication app, IWebHostEnvironment env)
    {
        if (!env.IsDevelopment())
        {
            app.UseHsts();
        }
        return app;
    }

    public static WebApplication UseHttpsRedirectionMiddleware(this WebApplication app)
    {
        app.UseHttpsRedirection();
        return app;
    }

    public static WebApplication UseStaticFilesMiddleware(this WebApplication app)
    {
        app.UseStaticFiles();
        return app;
    }

    public static WebApplication UseRoutingMiddleware(this WebApplication app)
    {
        app.UseRouting();
        return app;
    }

    public static WebApplication UseAuthorizationMiddleware(this WebApplication app)
    {
        app.UseAuthorization();
        return app;
    }

    public static WebApplication UseAuthenticationMiddleware(this WebApplication app)
    {
        app.UseAuthentication();
        return app;
    }

    public static WebApplication UseEndpointsMiddleware(this WebApplication app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "areaRoute",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
        return app;
    }

    public static WebApplication AddRazorPagesEndpoints(this WebApplication app)
    {
        app.MapRazorPages();
        return app;
    }
}