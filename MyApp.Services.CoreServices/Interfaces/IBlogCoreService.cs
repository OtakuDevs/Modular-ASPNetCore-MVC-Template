namespace MyApp.Services.CoreServices.Interfaces;

/// <summary>
/// Represents the core business logic layer of the application.
/// A core service processes requests from controllers, applies business rules,
/// and coordinates actions between data services and presentation services.
/// It acts as a bridge between the UI layer and the data access layer,
/// ensuring that the application's logic is centralized and reusable.
/// </summary>
public interface IBlogCoreService
{
    Task<string> PublishBlogAsync(int blogId);
}