using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Shared;
public class MasterCategoryConfig : IEntityTypeConfiguration<MasterCategory>
{
    public void Configure(EntityTypeBuilder<MasterCategory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired();
        builder.HasMany(x => x.MasterCategoryLanguage)
                .WithOne(x => x.MasterCategory)
                .HasForeignKey(x => x.MasterCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.Name }).IsUnique();
    }
}