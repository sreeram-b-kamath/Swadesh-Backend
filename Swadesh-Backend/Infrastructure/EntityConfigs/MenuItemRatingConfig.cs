using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Shared;
public class MenuItemRatingConfig : IEntityTypeConfiguration<MenuItemRating>
{
    public void Configure(EntityTypeBuilder<MenuItemRating> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.RestaurantId, x.SessionId, x.MenuItemId }).IsUnique();
    }
}