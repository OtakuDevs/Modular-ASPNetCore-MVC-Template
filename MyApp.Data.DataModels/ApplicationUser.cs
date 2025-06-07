using Microsoft.AspNetCore.Identity;
using MyApp.Data.DataModels.MappingTables;

namespace MyApp.Data.DataModels;

/// <summary>
/// Represents an application-specific user that extends the built-in ASP.NET Core IdentityUser.
/// </summary>
/// <remarks>
/// Inherits from <see cref="IdentityUser"/> to leverage the default identity system provided by ASP.NET Core,
/// including support for user authentication, roles, claims, and token management.
///
/// This class can be extended with additional properties to store user-specific data (e.g., FullName, ProfilePictureUrl).
/// Keeping this class separate allows the identity system to be customized without modifying the framework's core types.
/// </remarks>
public class ApplicationUser : IdentityUser
{
    public ICollection<BlogAuthor> Authors { get; set; } = null!;
}