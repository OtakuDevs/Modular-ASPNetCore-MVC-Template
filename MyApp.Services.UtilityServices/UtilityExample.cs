namespace MyApp.Services.UtilityServices;

/// <summary>
/// Provides helper methods for working with strings across the application.
/// </summary>
public class UtilityExample
{
    /// <summary>
    /// Converts a string to a URL-friendly "slug" format.
    /// </summary>
    /// <param name="input">The original string to convert.</param>
    /// <returns>A lowercase, hyphen-separated version of the input string.</returns>
    public static string ToSlug(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        return input
            .Trim()
            .ToLower()
            .Replace(" ", "-")
            .Replace("--", "-");
    }

    // Example
    // string slug = StringHelper.ToSlug("  This is a Blog Title  ");
    // Output: "this-is-a-blog-title"
}