using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Shared;
public class MenuFilterConfig : IEntityTypeConfiguration<MenuFilter>
{
    public void Configure(EntityTypeBuilder<MenuFilter> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
        .IsRequired();

        builder.Property(x => x.RestaurantId)
        .IsRequired();

        builder.Property(x => x.Active)
        .HasDefaultValue(true);

        builder.HasMany(x => x.MenuFilterlang)
       .WithOne(x => x.MenuFilters)
       .HasForeignKey(x => x.MenuFiltersId)
       .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.Name, x.RestaurantId }).IsUnique();
    }
}