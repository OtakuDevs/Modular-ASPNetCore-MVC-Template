using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Data.DataModels.MappingTables;

/// <summary>
/// Represents a many-to-many relationship between <see cref="ApplicationUser"/> and <see cref="Blog"/>.
/// This class serves as an example of how to implement a join table for modeling many-to-many relationships
/// in Entity Framework Core. It connects users (authors) to blogs, allowing:
/// - One user to author multiple blogs.
/// - One blog to have multiple authors.
///
/// To use this pattern:
/// 1. Add a <c>DbSet&lt;BlogAuthor&gt;</c> to your <c>AppDbContext</c>.
/// 2. Configure a composite primary key using the Fluent API in <c>OnModelCreating</c>.
/// </summary>
public class BlogAuthor
{
    [Required]
    [ForeignKey(nameof(ApplicationUser))]
    public string ApplicationUserId { get; set; } = null!;
    public ApplicationUser? ApplicationUser { get; set; }

    [Required]
    [ForeignKey(nameof(Blog))]
    public int BlogId { get; set; }
    public Blog? Blog { get; set; }
}