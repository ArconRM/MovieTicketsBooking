using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Entities;

namespace UserService.Repository.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UUID);

        builder.Property(u => u.UUID)
            .ValueGeneratedOnAdd();

        builder.Property(u => u.FullName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.PhoneNumber)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);
    }
}