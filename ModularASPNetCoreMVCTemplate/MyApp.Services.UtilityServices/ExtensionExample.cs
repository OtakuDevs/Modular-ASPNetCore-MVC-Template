namespace MyApp.Services.UtilityServices;

/// <summary>
/// Contains extension methods for simplifying common operations across the application.
/// </summary>
public static class ExtensionExample
{
    /// <summary>
    /// Converts a string title into a URL-friendly slug.
    /// </summary>
    /// <param name="title">The original title string.</param>
    /// <returns>A lowercased, hyphen-separated slug.</returns>
    public static string ToSlug(this string title)
    {
        return title.ToLower().Replace(" ", "-").Replace("--", "-");
    }

    // Example
    // string title = "Hello World";
    // string slug = title.ToSlug(); // Looks like string has a new method
}
