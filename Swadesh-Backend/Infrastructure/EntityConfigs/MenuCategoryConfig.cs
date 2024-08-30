using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Shared;
public class MenuCategoryConfig : IEntityTypeConfiguration<MenuCategory>
{
    public void Configure(EntityTypeBuilder<MenuCategory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
        .IsRequired();

        builder.Property(x => x.Uid)
        .IsRequired();

        builder.HasIndex(x => x.Uid)
        .IsUnique();        

        builder.Property(x => x.RestaurantId)
        .IsRequired();

        builder.Property(x => x.Active)
        .HasDefaultValue(true);

        /*builder.HasMany(x => x.MenuCategoryLanguage)
       .WithOne(x => x.MenuCategory)
       .HasForeignKey(x => x.MenuCategoryId)
       .OnDelete(DeleteBehavior.Cascade);*/

        builder.HasIndex(x => new { x.Name, x.RestaurantId }).IsUnique();
    }
}