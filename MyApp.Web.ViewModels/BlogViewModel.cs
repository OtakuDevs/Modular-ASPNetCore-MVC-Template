namespace MyApp.Web.ViewModels;

public class BlogViewModel
{
    public string Title { get; set; } = String.Empty;

    public string Content { get; set; } = String.Empty;

    public DateTime Created { get; set; } = DateTime.MinValue;

    public string Status { get; set; } = String.Empty;
}