using Microsoft.EntityFrameworkCore;
using MiniSchool.Domain.Entities;
using MiniSchool.Infrastructure.Configurations;

namespace MiniSchool.Infrastructure.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LessonConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}