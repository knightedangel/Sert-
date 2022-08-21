using System.ComponentModel.DataAnnotations;

namespace SApi.Models;

public class Lesson
{
    public int LessonId { get; set; }

    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }

    public string VideoUrl { get; set; }
    [Required]
    public string PostedDate { get; set; }

    [Required]
    public string TeacherPosted { get; set; }
}