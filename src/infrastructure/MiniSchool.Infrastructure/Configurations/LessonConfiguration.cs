using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniSchool.Domain.Entities;
using MiniSchool.Shared.Abstracts.Configurations;

namespace MiniSchool.Infrastructure.Configurations;

public class LessonConfiguration : BaseActiveEntityConfiguration<Lesson>
{
    public override void Configure(EntityTypeBuilder<Lesson> builder)
    {
        base.Configure(builder);

        builder.ToTable("lessons");

        builder.Property(p => p.Code)
            .IsRequired()
            .IsUnicode(false) 
            .HasColumnType("char(3)")
            .HasMaxLength(3)
            .HasColumnName("code");

        builder.Property(p => p.Name)
            .IsRequired()
            .IsUnicode(true)
            .HasMaxLength(30)
            .HasColumnName("name");

        builder.Property(p => p.ClassLevel)
            .IsRequired()
            .HasColumnType("tinyint")
            .HasColumnName("class_level");

        builder.Property(p => p.TeacherName)
            .IsRequired()
            .IsUnicode(true)
            .HasMaxLength(20)
            .HasColumnName("teacher_name");

        builder.Property(p => p.TeacherSurname)
            .IsRequired()
            .IsUnicode(true)
            .HasMaxLength(20)
            .HasColumnName("teacher_surname");

        builder.HasIndex(e => e.Code)
            .IsUnique()
            .HasFilter("is_archived = 0")
            .HasDatabaseName("ix_lesson_code_unique");
    }
}