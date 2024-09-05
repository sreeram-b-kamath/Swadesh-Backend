using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Enums;

namespace Shared;
public class RestaurantConfig : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(u => u.User)
               .WithOne()
               .HasForeignKey<Restaurant>(r => r.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Name).IsRequired();

        builder.Property(x => x.Active)
        .HasDefaultValue(true);

        builder.Property(x => x.InitialLogin)
        .HasDefaultValue(true);

       /* builder.HasMany(x => x.MenuCategories)
        .WithOne(x => x.Restaurant)
        .HasForeignKey(x => x.RestaurantId)
        .OnDelete(DeleteBehavior.Cascade);*/

        builder.HasMany(x => x.MenuFilters)
        .WithOne(x => x.Restaurant)
        .HasForeignKey(x => x.RestaurantId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.MenuItems)
        .WithOne(x => x.Restaurant)
        .HasForeignKey(x => x.RestaurantId)
        .OnDelete(DeleteBehavior.Cascade);

       /* builder.HasMany(x => x.MenuCategoryLangs)
       .WithOne(x => x.Restaurant)
       .HasForeignKey(x => x.RestaurantId)
       .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.MenuFiltersLangs)
        .WithOne(x => x.Restaurant)
        .HasForeignKey(x => x.RestaurantId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.MenuItemsLangs)
        .WithOne(x => x.Restaurant)
        .HasForeignKey(x => x.RestaurantId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.RestaurantLang)
       .WithOne(x => x.Restaurant)
       .HasForeignKey(x => x.RestaurantId)
       .OnDelete(DeleteBehavior.Cascade);*/

        builder.HasMany(x => x.MenuItemRatings)
       .WithOne(x => x.Restaurant)
       .HasForeignKey(x => x.RestaurantId)
       .OnDelete(DeleteBehavior.Cascade);
    }
}