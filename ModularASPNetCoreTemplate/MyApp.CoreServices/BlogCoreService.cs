using MyApp.DatabaseServices.Interfaces;

namespace MyApp.DatabaseServices;

public class BlogCoreService : IBlogCoreService
{
    private readonly BlogDataService _dataService;

    public BlogCoreService(BlogDataService dataService)
    {
        _dataService = dataService;
    }

    public async Task<string> PublishBlogAsync(int blogId)
    {
        var blog = await _dataService.GetPost(blogId);
        if (blog != null && !blog.IsPublished)
        {
            blog.IsPublished = true;
            await _dataService.SavePost(blog);
            return "Post published!";
        }
        return "Post not found or already published.";
    }
}