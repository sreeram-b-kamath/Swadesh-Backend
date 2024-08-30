using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigs
{
    public class MenuItemIngredientConfig : IEntityTypeConfiguration<MenuItemIngredients>
    {
        public void Configure(EntityTypeBuilder<MenuItemIngredients> builder)
        {
            builder.HasKey(u => new {u.MenuItemId,u.IngredientId});

            builder.HasOne(u => u.MenuItem)
                .WithMany(v => v.MenuItemIngredients)
                .HasForeignKey(u => u.MenuItemId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(u => u.Ingredients)
               .WithMany(v => v.MenuItemIngredients)
               .HasForeignKey(u => u.IngredientId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
