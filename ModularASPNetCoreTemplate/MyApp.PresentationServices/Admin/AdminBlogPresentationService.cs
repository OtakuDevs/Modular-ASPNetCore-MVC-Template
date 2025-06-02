using DataServices.Interfaces;
using MyApp.PresentationServices.Interfaces;

namespace MyApp.PresentationServices.Admin;

public class AdminBlogPresentationService : IAdminBlogPresentationService
{
    private readonly IBlogDataService _dataService;

    public AdminBlogPresentationService(IBlogDataService dataService)
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
            Author = blog.Author,
            AdminNotes = blog.AdminNotes
        };
        return viewmodel;
    }
}