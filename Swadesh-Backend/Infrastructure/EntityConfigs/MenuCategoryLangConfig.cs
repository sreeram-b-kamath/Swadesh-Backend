using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Shared;
public class MenuCategoryLangConfig : IEntityTypeConfiguration<MenuCategoryLang>
{
    public void Configure(EntityTypeBuilder<MenuCategoryLang> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.RestaurantId).IsRequired();
        builder.Property(x => x.Code).IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.MenuCategoryId).IsRequired();

        builder.HasIndex(x => new { x.MenuCategoryId, x.RestaurantId, x.Code }).IsUnique();
    }
}