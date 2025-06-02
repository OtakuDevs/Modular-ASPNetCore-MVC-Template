namespace MyApp.PresentationServices.Interfaces;

/// <summary>
/// Shapes and formats data for presentation in UI layers, such as building view models or API responses.
/// </summary>
public interface IBlogPresentationService
{
    Task<object> RetrieveBlogAsync(int blogId);
}