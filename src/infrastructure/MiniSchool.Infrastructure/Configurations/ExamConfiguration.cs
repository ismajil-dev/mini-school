using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniSchool.Domain.Entities;
using MiniSchool.Shared.Abstracts.Configurations;

namespace MiniSchool.Infrastructure.Configurations;

public class ExamConfiguration : BaseActiveEntityConfiguration<Exam>
{
    public override void Configure(EntityTypeBuilder<Exam> builder)
    {
        base.Configure(builder);

        builder.ToTable("exams");

        builder.Property(p => p.ExamDate)
            .IsRequired()
            .HasColumnType("date")
            .HasColumnName("exam_date");

        builder.Property(p => p.Grade)
            .IsRequired()
            .HasColumnType("tinyint") 
            .HasColumnName("grade");

        builder.Property(p => p.LessonId)
            .IsRequired()
            .HasColumnName("lesson_id");

        builder.Property(p => p.StudentId)
            .IsRequired()
            .HasColumnName("student_id");

        builder.HasIndex(e => e.LessonId)
            .HasDatabaseName("ix_exam_lesson_id");

        builder.HasIndex(e => e.StudentId)
            .HasDatabaseName("ix_exam_student_id");

        ConfigureLessonRelationship(builder);
        ConfigureStudentRelationship(builder);
    }

    protected virtual void ConfigureLessonRelationship(EntityTypeBuilder<Exam> builder)
    {
        builder.HasOne(e => e.Lesson)
            .WithMany(l => l.Exams)
            .HasForeignKey(e => e.LessonId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }

    protected virtual void ConfigureStudentRelationship(EntityTypeBuilder<Exam> builder)
    {
        builder.HasOne(e => e.Student)
            .WithMany(s => s.Exams)
            .HasForeignKey(e => e.StudentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
    }
}