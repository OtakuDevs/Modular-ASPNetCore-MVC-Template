namespace MyApp.Services.Abstractions.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class AutoRegisterServiceAttribute : Attribute
{
    public ServiceLifetimeType Lifetime { get; }

    public AutoRegisterServiceAttribute(ServiceLifetimeType lifetime = ServiceLifetimeType.Scoped)
    {
        Lifetime = lifetime;
    }
}