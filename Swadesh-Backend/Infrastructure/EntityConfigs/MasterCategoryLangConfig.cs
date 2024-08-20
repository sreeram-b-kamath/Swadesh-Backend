using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Shared;
public class MasterCategoryLangConfig : IEntityTypeConfiguration<MasterCategoryLang>
{
    public void Configure(EntityTypeBuilder<MasterCategoryLang> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Code).IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.MasterCategoryId).IsRequired();
        
        builder.HasIndex(x => new { x.MasterCategoryId, x.Code }).IsUnique();
    }
}