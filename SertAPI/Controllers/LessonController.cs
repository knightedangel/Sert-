using SApi.Models;
using SApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonController : ControllerBase 
{
    private readonly ILogger<LessonController> _logger;
    private readonly ILessonRepository _lessonRepository;

    public LessonController(ILogger<LessonController> logger, ILessonRepository repository)
    {
        _logger = logger;
        _lessonRepository = repository;
    }

    [HttpGet]
public ActionResult<IEnumerable<Lesson>> GetLesson() 
{
    return Ok(_lessonRepository.GetAllLesson());
}
[HttpGet]
[Route("{lessonId:int}")]
public ActionResult<Lesson> GetLessonById(int lessonId) 
{
    var lesson = _lessonRepository.GetLessonById(lessonId);
    if (lesson == null) {
        return NotFound();
    }
    return Ok(lesson);
}

[HttpPost]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public ActionResult<Lesson> CreateLesson(Lesson lesson) 
{
    if (!ModelState.IsValid || lesson == null) {
        return BadRequest();
    }
    var newLesson = _lessonRepository.CreateLesson(lesson);
    return Created(nameof(GetLessonById), newLesson);
}


[HttpPut]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("{lessonId:int}")]
public ActionResult<Lesson> UpdateLesson(Lesson lesson) 
{
    if (!ModelState.IsValid || lesson == null) {
        return BadRequest();
    }
    return Ok(_lessonRepository.UpdateLesson(lesson));
}
[HttpDelete]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("{lessonId:int}")]
public ActionResult DeleteLesson(int lessonId) 
{
    _lessonRepository.DeleteLessonById(lessonId); 
    return NoContent();
}
}


