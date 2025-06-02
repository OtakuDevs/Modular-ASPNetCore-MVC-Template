using DataServices.Interfaces;

namespace DataServices;

public class BlogDataService : IBlogDataService
{
    private readonly DbContext _context;

    public BlogDataService(DbContext context)
    {
        _context = context;
    }

    public async Task<Blog> GetBlogAsync(int blogId)
    {
       var blog = await _context.Blogs.FirstOrDefault(b => b.Id == blogId);
       return blog;
    }

    public async Task<string> SaveBlogAsync(Blog blog)
    {
       _context.Update(blog);
       await _context.SaveChangesAsync();
       return "Blog updated!";
    }
}