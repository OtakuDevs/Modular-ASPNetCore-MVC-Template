using Microsoft.EntityFrameworkCore;
using MyApp.Data.Database;
using MyApp.Data.DataModels;
using MyApp.Services.Abstractions.Attributes;
using MyApp.Services.DataServices.Interfaces;

namespace MyApp.Services.DataServices;

[AutoRegisterService(ServiceLifetimeType.Scoped)]
public class BlogDataService : IBlogDataService
{
    private readonly AppDbContext _context;

    public BlogDataService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Blog> GetBlogAsync(int blogId)
    {
        var blog = await _context.Blogs.FirstOrDefaultAsync(b => b.Id == blogId);
        return blog;
    }

    public async Task<string> SaveBlogAsync(Blog blog)
    {
        _context.Blogs.Update(blog);
        await _context.SaveChangesAsync();
        return "Blog updated!";
    }
}