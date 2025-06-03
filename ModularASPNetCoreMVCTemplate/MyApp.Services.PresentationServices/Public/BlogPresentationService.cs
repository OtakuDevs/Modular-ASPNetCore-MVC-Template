using MyApp.Services.DataServices.Interfaces;
using MyApp.Services.PresentationServices.Public.Interfaces;

namespace MyApp.Services.PresentationServices.Public;

public class BlogPresentationService : IBlogPresentationService
{
    private readonly IBlogDataService _dataService;

    public BlogPresentationService(IBlogDataService dataService)
    {
        _dataService = dataService;
    }

    public async Task<object> RetrieveBlogAsync(int blogId)
    {
        var blog = await _dataService.GetBlogAsync(blogId);
        object viewmodel = new
        {
            Title = blog.Title,
            Content = blog.Content,
            Status = blog.Status.ToString(),
            Created = blog.Created,
        };
        return viewmodel;
    }
}