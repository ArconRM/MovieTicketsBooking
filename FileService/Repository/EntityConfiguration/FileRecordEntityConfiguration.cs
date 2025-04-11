using FileService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileService.Repository.EntityConfiguration;

public class FileRecordEntityConfiguration : IEntityTypeConfiguration<FileRecord>
{
    public void Configure(EntityTypeBuilder<FileRecord> builder)
    {
        builder.HasKey(fr => fr.UUID);

        builder.Property(fr => fr.UUID)
            .ValueGeneratedOnAdd();

        builder.Property(fr => fr.ContentType)
            .IsRequired();

        builder.Property(fr => fr.PhysFileName)
            .IsRequired();

        builder.Property(fr => fr.StoredFileName)
            .IsRequired();

        builder.Property(fr => fr.Size)
            .IsRequired();

        builder.Property(fr => fr.UploadedAt)
            .IsRequired();
    }
}