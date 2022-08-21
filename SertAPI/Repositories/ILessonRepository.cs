using SApi.Models;

namespace SApi.Repositories;

public interface ILessonRepository
{
    IEnumerable<Lesson> GetAllLesson();
    Lesson? GetLessonById(int lessonId);
    Lesson CreateLesson(Lesson newLesson);
    Lesson? UpdateLesson(Lesson newLesson);
    void DeleteLessonById(int lessonId);

}