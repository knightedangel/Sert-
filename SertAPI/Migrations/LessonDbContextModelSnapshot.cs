// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SApi.Migrations;

#nullable disable

namespace SertAPI.Migrations
{
    [DbContext(typeof(LessonDbContext))]
    partial class LessonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("SApi.Models.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostedDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TeacherPosted")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LessonId");

                    b.ToTable("Lesson");

                    b.HasData(
                        new
                        {
                            LessonId = 1,
                            Description = "The muppets are a timeless classic, Watch the assigned video then write a 4 page essey about the story devices used.",
                            PostedDate = "01.20.2001",
                            TeacherPosted = "Micah I.",
                            Title = "Intro to the muppets: part 1",
                            VideoUrl = "https://www.youtube.com/watch?v=1y06G853Udg&ab_channel=AmoryPazyluz"
                        },
                        new
                        {
                            LessonId = 2,
                            Description = "The muppets are a timeless classic, Watch the assigned video then write a 4 page essey about the story devices used.",
                            PostedDate = "01.20.2001",
                            TeacherPosted = "Micah I.",
                            Title = "Intro to the muppets: part 2",
                            VideoUrl = "https://www.youtube.com/watch?v=1y06G853Udg&ab_channel=AmoryPazyluz"
                        });
                });

            modelBuilder.Entity("SApi.tokens.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
