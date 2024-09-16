using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Enums;
using System.Data;
using System.Reflection.Emit;

namespace Shared;
public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(u => u.Name)
           .IsRequired()
           .HasMaxLength(100);

        builder.Property(x => x.Role)
        .HasDefaultValue(UserRoles.Chef);

        builder.Property(x => x.Email)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(x => x.IsEmailVerified)
        .HasDefaultValue(false);

        builder.Property(x => x.Mobile)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(x => x.Active)
       .HasDefaultValue(true);

        builder.Property(x => x.OTPUsed)
        .HasDefaultValue(false);

        builder.Property(u => u.Password)
        .IsRequired()
        .HasMaxLength(1500);

        builder.Ignore(u=>u.ConcurrencyStamp).Ignore(u=>u.NormalizedEmail).Ignore(u=>u.NormalizedUserName).Ignore(u=>u.SecurityStamp).Ignore(u=>u.AccessFailedCount).Ignore(u=>u.LockoutEnabled).Ignore(u=>u.LockoutEnd).Ignore(u=>u.PhoneNumber).Ignore(u => u.PhoneNumberConfirmed);
    }
}