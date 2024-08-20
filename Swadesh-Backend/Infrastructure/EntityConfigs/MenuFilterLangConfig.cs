using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Shared;
public class MenuFilterLangConfig : IEntityTypeConfiguration<MenuFilterLang>
{
    public void Configure(EntityTypeBuilder<MenuFilterLang> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.RestaurantId).IsRequired();
        builder.Property(x => x.MenuFiltersId).IsRequired();

        builder.HasIndex(x => new { x.MenuFiltersId, x.RestaurantId, x.Code }).IsUnique();
    }
}