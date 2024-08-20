using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shared;


public class ErrorMessageConfig : IEntityTypeConfiguration<ErrorMessage>
{
    public void Configure(EntityTypeBuilder<ErrorMessage> builder)
    {
        builder.HasKey(x => x.Id);
    }
}