using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigs
{
    public class IngredientConfig : IEntityTypeConfiguration<Ingredients>
    {
        public void Configure(EntityTypeBuilder<Ingredients> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasData(
                new Ingredients { Id = 1, Name = "Vegetables", image = "tomato.png" },
            new Ingredients { Id = 2, Name = "Chicken", image = "cheese.png" }
                );
        }
    }
}
