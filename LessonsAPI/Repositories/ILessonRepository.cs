using System.Collections.Generic;
using l14_coffeeAPI.Models;

namespace l14_coffeeAPI.Repositories;
public interface ILessonRepository
{
    IEnumerable<Lesson> GetAllCoffee();
    Lesson? GetLessonById(int lessonId);
    Lesson CreateLesson(Lesson newLesson);
    Lesson? UpdateLesson(Lesson newLesson);
    void DeleteLessonById(int lessonId);

}