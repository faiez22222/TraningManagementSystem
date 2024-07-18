using CourseManagementService.Model;
using CourseManagementService.Services.CourseCalendarService;
using CourseManagementService.Services.CourseService;
using CourseManagementService.Services.DailyTaskService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            await _courseService.AddCourseAsync(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course course)
        {
            if (id != course.Id) return BadRequest();
            await _courseService.UpdateCourseAsync(course);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseService.DeleteCourseAsync(id);
            return NoContent();
        }
    }
}
