using System.ComponentModel.DataAnnotations;

namespace l14_coffeeAPI.Models;

public class Lesson 
{
    public int LessonId { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]

    public string? Description { get; set; }

    public string? VideoUrl { get; set; }

    public string? TestUrl { get; set; }

    public string TeacherDate { get; set; }
    
    
}