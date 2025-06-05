using MyApp.Data.DataModels.Enums;
using MyApp.Services.Abstractions.Attributes;
using MyApp.Services.CoreServices.Interfaces;
using MyApp.Services.DataServices.Interfaces;

namespace MyApp.Services.CoreServices;

[AutoRegisterService(ServiceLifetimeType.Scoped)]
public class BlogCoreService : IBlogCoreService
{
    private readonly IBlogDataService _dataService;

    public BlogCoreService(IBlogDataService dataService)
    {
        _dataService = dataService;
    }

    public async Task<string> PublishBlogAsync(int blogId)
    {
        var blog = await _dataService.GetBlogAsync(blogId);
        if (blog != null)
        {
            blog.Status = Enum.GetValues<BlogStatus>()[1];
            await _dataService.SaveBlogAsync(blog);
            return "Post published!";
        }
        return "Post not found or already published.";
    }
}