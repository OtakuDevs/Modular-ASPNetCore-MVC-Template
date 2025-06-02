namespace MyApp.DatabaseServices.Interfaces;

/// <summary>
/// Contains business logic for executing core domain actions, such as processing input,
/// validating rules, or coordinating operations across data sources.
/// </summary>
public interface IBlogCoreService
{
    Task<string> PublishBlogAsync(int blogId);
}