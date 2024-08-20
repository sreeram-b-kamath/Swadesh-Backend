using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Shared;
public class MasterFilterConfig : IEntityTypeConfiguration<MasterFilter>
{
    public void Configure(EntityTypeBuilder<MasterFilter> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired();    
        builder.HasMany(x => x.MasterFilterLanguage)
                .WithOne(x => x.MasterFilter)
                .HasForeignKey(x => x.MasterFilterId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.Name }).IsUnique();
    }
}