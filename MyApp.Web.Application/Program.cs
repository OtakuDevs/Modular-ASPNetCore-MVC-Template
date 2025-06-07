using MyApp.Extensions;

namespace MyApp;

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
            .AddDeveloperPageException(builder.Environment)
            .AddApplicationServices();

        var webApplication = builder.Build();
        webApplication
            .ApplyMigrations(webApplication.Environment)
            .UseDeveloperExceptionPageMiddleware(webApplication.Environment)
            .UseExceptionHandlerMiddleware(webApplication.Environment)
            .UseSecureConnectionMiddleware(webApplication.Environment)
            .UseHttpsRedirectionMiddleware()
            .UseStaticFilesMiddleware()
            .UseRoutingMiddleware()
            .UseAuthorizationMiddleware()
            .UseAuthenticationMiddleware()
            .UseEndpointsMiddleware()
            .AddRazorPagesEndpoints();

        webApplication.Run();
    }
}