using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SertAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    VideoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    PostedDate = table.Column<string>(type: "TEXT", nullable: false),
                    TeacherPosted = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.LessonId);
                });

            migrationBuilder.InsertData(
                table: "Lesson",
                columns: new[] { "LessonId", "Description", "PostedDate", "TeacherPosted", "Title", "VideoUrl" },
                values: new object[] { 1, "The muppets are a timeless classic, Watch the assigned video then write a 4 page essey about the story devices used.", "01.20.2001", "Micah I.", "Intro to the muppets: part 1", "https://www.youtube.com/watch?v=1y06G853Udg&ab_channel=AmoryPazyluz" });

            migrationBuilder.InsertData(
                table: "Lesson",
                columns: new[] { "LessonId", "Description", "PostedDate", "TeacherPosted", "Title", "VideoUrl" },
                values: new object[] { 2, "The muppets are a timeless classic, Watch the assigned video then write a 4 page essey about the story devices used.", "01.20.2001", "Micah I.", "Intro to the muppets: part 2", "https://www.youtube.com/watch?v=1y06G853Udg&ab_channel=AmoryPazyluz" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lesson");
        }
    }
}
