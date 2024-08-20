using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Shared;
public class MasterFilterLangConfig : IEntityTypeConfiguration<MasterFilterLang>
{
    public void Configure(EntityTypeBuilder<MasterFilterLang> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Code).IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.MasterFilterId).IsRequired();

        builder.HasIndex(x => new { x.MasterFilterId, x.Code }).IsUnique();
    }
}