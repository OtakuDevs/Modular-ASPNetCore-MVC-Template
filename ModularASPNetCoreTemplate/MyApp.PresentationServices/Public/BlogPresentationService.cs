using DataServices.Interfaces;
using MyApp.PresentationServices.Interfaces;

namespace MyApp.PresentationServices.Public;

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
            Author = blog.Author
        };
        return viewmodel;
    }
}