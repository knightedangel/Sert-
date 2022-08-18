using l14_coffeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace l14_coffeeAPI.Migrations;

public class LessonDbContext : DbContext
{
    public DbSet<Lesson> Lesson { get; set; }
    public DbSet<User> Users { get; set; }

    public LessonDbContext(DbContextOptions<LessonDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.LessonId);
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.TeacherDate).IsRequired();
            entity.Property(e => e.TestUrl).IsRequired();
            entity.Property(e => e.VideoUrl).IsRequired();
        });

        modelBuilder.Entity<Lesson>().HasData(
            new Lesson
            {
                LessonId = 1,
                Title = "Intro to Muppets",
                VideoUrl = "https://www.youtube.com/embed/tgbNymZ7vqY?autoplay=0&mute=0",
                TestUrl = "https://forms.gle/GgWVvLBa6mrz1M999",
                Description = "Manamana, do do do doo do",
                TeacherDate = "Jim Henson, 22, 2001"
            }
        );

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.Email).IsRequired();
            entity.HasIndex(x => x.Email).IsUnique();
            entity.Property(e => e.Password).IsRequired();
        });
    }
}