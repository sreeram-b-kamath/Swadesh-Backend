using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Shared;
public class MenuItemLangConfig : IEntityTypeConfiguration<MenuItemLang>
{
    public void Configure(EntityTypeBuilder<MenuItemLang> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.MenuItemsId).IsRequired();
        builder.Property(x => x.RestaurantId).IsRequired();

        builder.HasIndex(x => new { x.MenuItemsId, x.RestaurantId, x.Code }).IsUnique();
    }
}