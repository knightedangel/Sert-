using l14_coffeeAPI.Migrations;
using l14_coffeeAPI.Models;

namespace l14_coffeeAPI.Repositories;

public class LessonRepository : ILessonRepository 
{
    private readonly LessonDbContext _context;

    public LessonRepository(LessonDbContext context)
    {
        _context = context;
    }

    public Lesson CreateLesson(Lesson newLesson)
    {
        _context.Lesson.Add(newLesson);
        _context.SaveChanges();
        return newLesson;
    }

    public void DeleteLessonById(int lessonId)
    {
        var lesson = _context.Lesson.Find(lessonId);
        if (lesson != null) {
            _context.Lesson.Remove(lesson); 
            _context.SaveChanges(); 
        }
    }

    public IEnumerable<Lesson> GetAllCoffee()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Lesson> GetAllLesson()
    {
        return _context.Lesson.ToList();
    }

    public Lesson? GetLessonById(int lessonId)
    {
        return _context.Lesson.SingleOrDefault(c => c.LessonId == lessonId);
    }

    public Lesson? UpdateLesson(Lesson newLesson)
    {
        var originalLesson = _context.Lesson.Find(newLesson.LessonId);
        if (originalLesson != null)
        {
            originalLesson.Title = newLesson.Title;
            originalLesson.Description = newLesson.Description;
            originalLesson.VideoUrl = newLesson.VideoUrl;
            originalLesson.TestUrl = newLesson.TestUrl;
            originalLesson.TeacherDate = newLesson.TeacherDate;
            _context.SaveChanges();
        }
        return originalLesson;
    }
}