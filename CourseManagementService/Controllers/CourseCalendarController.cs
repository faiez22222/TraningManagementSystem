using CourseManagementService.Model;
using CourseManagementService.Services.CourseCalendarService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCalendarController : ControllerBase
    {
        private readonly ICourseCalendarService _courseCalendarService;

        public CourseCalendarController(ICourseCalendarService courseCalendarService)
        {
            _courseCalendarService = courseCalendarService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseCalendarById(int id)
        {
            var courseCalendar = await _courseCalendarService.GetCourseCalendarByIdAsync(id);
            if (courseCalendar == null) return NotFound();
            return Ok(courseCalendar);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourseCalendar([FromBody] CourseCalendar courseCalendar)
        {
            await _courseCalendarService.AddCourseCalendarAsync(courseCalendar);
            return CreatedAtAction(nameof(GetCourseCalendarById), new { id = courseCalendar.Id }, courseCalendar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourseCalendar(int id, [FromBody] CourseCalendar courseCalendar)
        {
            if (id != courseCalendar.Id) return BadRequest();
            await _courseCalendarService.UpdateCourseCalendarAsync(courseCalendar);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseCalendar(int id)
        {
            await _courseCalendarService.DeleteCourseCalendarAsync(id);
            return NoContent();
        }
    }
}
