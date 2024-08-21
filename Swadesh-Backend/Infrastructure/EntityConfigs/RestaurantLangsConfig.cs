using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Shared;
public class RestaurantLangsConfig : IEntityTypeConfiguration<RestaurantLang>
{
    public void Configure(EntityTypeBuilder<RestaurantLang> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired();

        builder.HasIndex(x => new { x.RestaurantId, x.Code }).IsUnique();
    }
}