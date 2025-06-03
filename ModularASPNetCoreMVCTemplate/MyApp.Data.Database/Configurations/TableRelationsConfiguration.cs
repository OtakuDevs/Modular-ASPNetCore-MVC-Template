using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Data.DataModels.MappingTables;

namespace MyApp.Data.Database.Configurations;

/// <summary>
/// Configures the key relationships and mappings for various tables in the database.
/// Implements the <see cref="IEntityTypeConfiguration{TEntity}"/> interface for multiple entity types:
/// </summary>
public class TableRelationsConfiguration :IEntityTypeConfiguration<BlogAuthor>
{
    public void Configure(EntityTypeBuilder<BlogAuthor> builder)
    {
        builder.HasKey(ba => new { ba.ApplicationUserId, ba.BlogId });
    }
}