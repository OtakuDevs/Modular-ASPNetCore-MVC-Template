using MyApp.Data.DataModels;

namespace MyApp.Services.DataServices.Interfaces;

/// <summary>
/// Handles data access and persistence, including queries and updates to the database or external storage.
/// </summary>
public interface IBlogDataService
{
    Task<Blog> GetBlogAsync(int blogId);

    Task<string> SaveBlogAsync(Blog blog);
}