namespace MyApp.Common.ValidationConstants;

/// <summary>
/// Contains constants related to data model constraints such as
/// maximum lengths, field size limits, and database-specific values
/// used to maintain consistency and avoid magic numbers in entity definitions.
/// </summary>
public static class DataModelsConstants
{
    public static class UserConstants
    {
        public const string EmailConst = "Email";
    }

    public static class BlogConstants
    {
        public const int ExampleMinLength = 80;
    }
}