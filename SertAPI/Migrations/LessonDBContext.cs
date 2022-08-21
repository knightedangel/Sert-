using  SApi.Models;
using Microsoft.EntityFrameworkCore;
using SApi.tokens.Models;

namespace SApi.Migrations;

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
            entity.Property(e => e.VideoUrl).IsRequired();
            entity.Property(e => e.PostedDate).IsRequired();
            entity.Property(e => e.TeacherPosted).IsRequired();
        });
        modelBuilder.Entity<User>(entity =>
{
    entity.HasKey(e => e.UserId);
    entity.Property(e => e.Email).IsRequired();
    entity.HasIndex(x => x.Email).IsUnique();
    entity.Property(e => e.Password).IsRequired();
});


        modelBuilder.Entity<Lesson>().HasData(
    new Lesson { 
           LessonId = 1,
            Title = "Intro to the muppets: part 1",
            Description= "The muppets are a timeless classic, Watch the assigned video then write a 4 page essey about the story devices used.",
            VideoUrl ="https://www.youtube.com/watch?v=1y06G853Udg&ab_channel=AmoryPazyluz",
            PostedDate ="01.20.2001",
            TeacherPosted="Micah I."
    },
      new Lesson { 
          LessonId = 2,
            Title = "Intro to the muppets: part 2",
            Description= "The muppets are a timeless classic, Watch the assigned video then write a 4 page essey about the story devices used.",
            VideoUrl ="https://www.youtube.com/watch?v=1y06G853Udg&ab_channel=AmoryPazyluz",
            PostedDate ="01.20.2001",
            TeacherPosted="Micah I."
    }
   
);
    }
}