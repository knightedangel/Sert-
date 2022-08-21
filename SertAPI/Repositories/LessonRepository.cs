using SApi.Repositories;
using SApi.Migrations;
using SApi.Models;

namespace SApi.Repositories;

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
        var existingLesson = _context.Lesson.Find(newLesson.LessonId);
        if (existingLesson != null) {
            existingLesson.Title = newLesson.Title;
            existingLesson.Description = newLesson.Description;
            existingLesson.VideoUrl = newLesson.VideoUrl;
            existingLesson.PostedDate = newLesson.PostedDate;
            existingLesson.TeacherPosted = newLesson.TeacherPosted;
        }
        return existingLesson;
    }
}