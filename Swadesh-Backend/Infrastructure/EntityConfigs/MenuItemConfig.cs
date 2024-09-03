using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Shared;
public class MenuItemConfig : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
        .IsRequired();

        builder.Property(x => x.uid).
        IsRequired();

        builder.Property(x => x.PrimaryImage)
        .IsRequired();

        builder.Property(x => x.Description)
        .IsRequired();

        builder.Property(x => x.Money)
        .HasColumnType("money")
        .IsRequired();

       /* builder.Property(x => x.Currency)
        .IsRequired();*/

        builder.Property(x => x.Active)
        .HasDefaultValue(true);

     /*   builder.HasMany(x => x.MenuItemslang)
       .WithOne(x => x.MenuItems)
       .HasForeignKey(x => x.MenuItemsId)
       .OnDelete(DeleteBehavior.Cascade);*/

        builder.HasMany(x => x.MenuItemRatings)
        .WithOne(x => x.MenuItem)
        .HasForeignKey(x => x.MenuItemId)
        .OnDelete(DeleteBehavior.Cascade);
    }
}