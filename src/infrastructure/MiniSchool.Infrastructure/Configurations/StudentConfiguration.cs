using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniSchool.Domain.Entities;
using MiniSchool.Shared.Abstracts.Configurations;

namespace MiniSchool.Infrastructure.Configurations;

public class StudentConfiguration : BaseActiveEntityConfiguration<Student>
{
    public override void Configure(EntityTypeBuilder<Student> builder)
    {
        base.Configure(builder);

        builder.ToTable("students");

        builder.Property(p => p.Name)
            .IsRequired()
            .IsUnicode(true)
            .HasMaxLength(30)
            .HasColumnName("name");

        builder.Property(p => p.Surname)
            .IsRequired()
            .IsUnicode(true)
            .HasMaxLength(30)
            .HasColumnName("surname");

        builder.Property(p => p.ClassLevel)
            .IsRequired()
            .HasColumnType("tinyint")
            .HasColumnName("class_level");
    }
}
