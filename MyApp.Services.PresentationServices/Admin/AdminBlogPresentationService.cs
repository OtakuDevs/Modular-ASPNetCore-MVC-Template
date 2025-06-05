using MyApp.Services.Abstractions.Attributes;
using MyApp.Services.DataServices.Interfaces;
using MyApp.Services.PresentationServices.Admin.Interfaces;

namespace MyApp.Services.PresentationServices.Admin;

[AutoRegisterService(ServiceLifetimeType.Scoped)]
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
            Status = blog.Status.ToString(),
            Created = blog.Created,
            AdminNotes = blog.AdminNotes
        };
        return viewmodel;
    }
}