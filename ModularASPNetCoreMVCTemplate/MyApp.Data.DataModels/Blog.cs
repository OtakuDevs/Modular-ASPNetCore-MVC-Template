using System.ComponentModel.DataAnnotations;
using MyApp.Data.DataModels.Enums;
using MyApp.Data.DataModels.MappingTables;
using static MyApp.Common.ValidationConstants.DataModelsConstants;

namespace MyApp.Data.DataModels;

public class Blog
{
    public int Id { get; set; }

    [Required]
    [MaxLength(BlogConstants.ExampleMinLength)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(BlogConstants.ExampleMinLength)]
    public string Content { get; set; } = null!;

    [Required]
    [MaxLength(BlogConstants.ExampleMinLength)]
    public string AdminNotes { get; set; } = null!;

    public DateTime Created { get; set; }

    public BlogStatus Status { get; set; }

    public ICollection<BlogAuthor> Authors { get; set; } = null!;
}