using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModularASPNetCoreMVCTemplate.Extensions;
using MyApp.Data.Database;
using MyApp.Data.DataModels;
using MyApp.Services.Abstractions.Attributes;

namespace MyApp.Extensions;

/// <summary>
/// Provides extension methods for registering services and configuration sources
/// into the dependency injection container and application builder, including environment variables
/// and application-specific services such as the database context.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddEnvironmentVariablesConfig(this WebApplicationBuilder builder)
    {
        builder
            .Configuration.AddEnvironmentVariables();
        return builder;
    }

    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }

    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services
            .AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.ConfigureIdentityOptions)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();
        return services;
    }

    public static IServiceCollection AddControllersWithViewsService(this IServiceCollection services,
        IWebHostEnvironment environment)
    {
        var serviceRef = services.AddControllersWithViews(options =>
        {
            options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
        });

        if (environment.IsDevelopment())
        {
            serviceRef.AddRazorRuntimeCompilation();
        }

        return services;
    }

    public static IServiceCollection AddCookiePolicy(this IServiceCollection services)
    {
        services
            .Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
            });
        return services;
    }

    public static IServiceCollection AddDeveloperPageException(this IServiceCollection services,
        IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            return services.AddDatabaseDeveloperPageExceptionFilter();
        }

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        LoadReferencedAssemblies();

        var typesWithAttribute = AppDomain.CurrentDomain
            .GetAssemblies()
            .Where(a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.Location))
            .SelectMany(a => a.GetExportedTypes())
            .Where(t =>
                t.IsClass &&
                !t.IsAbstract &&
                t.GetCustomAttributes(typeof(AutoRegisterServiceAttribute), false).Length > 0);
        foreach (var type in typesWithAttribute)
        {
            var attribute =
                (AutoRegisterServiceAttribute)type.GetCustomAttributes(typeof(AutoRegisterServiceAttribute), false)
                    .First();
            var serviceInterfaces = type.GetInterfaces();
            foreach (var serviceType in serviceInterfaces)
            {
                switch (attribute.Lifetime)
                {
                    case ServiceLifetimeType.Singleton:
                        services.AddSingleton(serviceType, type);
                        break;
                    case ServiceLifetimeType.Scoped:
                        services.AddScoped(serviceType, type);
                        break;
                    case ServiceLifetimeType.Transient:
                        services.AddTransient(serviceType, type);
                        break;
                }
            }
        }

        return services;
    }

    private static void LoadReferencedAssemblies()
    {
        var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        var referencedPaths = Directory.GetFiles(AppContext.BaseDirectory, "*.dll");

        foreach (var path in referencedPaths)
        {
            try
            {
                var assemblyName = AssemblyName.GetAssemblyName(path);
                if (loadedAssemblies.All(a => a.FullName != assemblyName.FullName))
                {
                    AppDomain.CurrentDomain.Load(assemblyName);
                }
            }
            catch
            {
                // Ignore non-.NET DLLs or invalid assemblies
            }
        }
    }
}