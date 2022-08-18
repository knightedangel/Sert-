using l14_coffeeAPI.Models;
using l14_coffeeAPI.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace l14_coffeeAPI.Controllers
{
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
            return Ok(_lessonRepository.GetAllCoffee());
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
        public ActionResult<Lesson> CreateCoffee(Lesson lesson) 
        {
            if (!ModelState.IsValid || lesson == null) {
                return BadRequest();
            }
            var newLesson = _lessonRepository.CreateLesson(lesson);
            return Created(nameof(GetLessonById), newLesson);
        }

        [HttpPut]
        [Route("{lessonId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Lesson> UpdateLesson(Lesson lesson) 
        {
            if (!ModelState.IsValid || lesson == null) {
                return BadRequest();
            }
            return Ok(_lessonRepository.UpdateLesson(lesson));
        }

        [HttpDelete]
        [Route("{lessonId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult DeleteLesson(int lessonId) 
        {
            _lessonRepository.DeleteLessonById(lessonId); 
            return NoContent();
        }
    }
}