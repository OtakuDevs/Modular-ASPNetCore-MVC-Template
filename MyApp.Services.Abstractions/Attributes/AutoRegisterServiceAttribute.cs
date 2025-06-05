namespace MyApp.Services.Abstractions.Attributes;

/// <summary>
/// Custom attribute applied to service classes to enable automatic registration
/// in the dependency injection (DI) container. Supports specifying a service lifetime,
/// such as Scoped, Singleton, or Transient, via the <see cref="Lifetime"/> property.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class AutoRegisterServiceAttribute : Attribute
{
    public ServiceLifetimeType Lifetime { get; }

    public AutoRegisterServiceAttribute(ServiceLifetimeType lifetime = ServiceLifetimeType.Scoped)
    {
        Lifetime = lifetime;
    }
}