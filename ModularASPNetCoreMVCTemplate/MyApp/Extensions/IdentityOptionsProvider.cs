using Microsoft.AspNetCore.Identity;

namespace ModularASPNetCoreMVCTemplate.Extensions;

public static class IdentityOptionsProvider
{
    public static void ConfigureIdentityOptions(IdentityOptions options)
    {
        options.Lockout.AllowedForNewUsers = false;
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 12;
    }
}