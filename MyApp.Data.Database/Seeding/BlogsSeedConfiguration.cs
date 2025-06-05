using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Data.DataModels;
using MyApp.Data.DataModels.Enums;

namespace MyApp.Data.Database.Seeding;

/// <summary>
/// Provides the default configuration for seeding initial entity data
/// into the database using Entity Framework Core.
/// </summary>
public class BlogsSeedConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        var blogs = new List<Blog>
        {
            new Blog()
            {
                Id = 1,
                Title = "Template Title",
                Content = "Template Content",
                AdminNotes = "Template Admin Notes",
                Created = DateTime.Now,
                Status = BlogStatus.PendingReview
            },
        };
        builder.HasData(blogs);
    }
}