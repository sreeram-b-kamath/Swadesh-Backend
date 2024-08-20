using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Enums;

namespace Shared;
public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(u => u.FirstName)
           .IsRequired()
           .HasMaxLength(100);

        builder.Property(x => x.LastName)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(x => x.Role)
        .HasDefaultValue(UserRoles.Chef);

        builder.Property(x => x.Email)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(x => x.IsEmailVerified)
        .HasDefaultValue(false);

        builder.Property(x => x.CountryCode)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(x => x.Mobile)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(x => x.IsMobileVerified)
        .HasDefaultValue(false);

        builder.Property(x => x.Active)
       .HasDefaultValue(true);

        builder.Property(x => x.OTPUsed)
        .HasDefaultValue(false);

        builder.Property(u => u.Password)
        .IsRequired()
        .HasMaxLength(1500);
    }
}