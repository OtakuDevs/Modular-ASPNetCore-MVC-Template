using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApp.Data.Database.Configurations;
using MyApp.Data.Database.Seeding;
using MyApp.Data.DataModels;
using MyApp.Data.DataModels.MappingTables;

namespace MyApp.Data.Database;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Blog> Blogs { get; set; }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public DbSet<BlogAuthor> BlogAuthors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        ApplyConfigurations(builder);
        SeedData(builder);

        base.OnModelCreating(builder);
    }

    private static void ApplyConfigurations(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TableRelationsConfiguration());
        builder.ApplyConfiguration(new DefaultRolesConfiguration());
    }

    private static void SeedData(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new BlogsSeedConfiguration());
    }
}