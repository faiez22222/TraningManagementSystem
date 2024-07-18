using CourseManagementService.Model;
using CourseManagementService.Services.DailyTaskService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class DailyTaskController : ControllerBase
    {
        private readonly IDailyTaskService _dailyTaskService;

        public DailyTaskController(IDailyTaskService dailyTaskService)
        {
            _dailyTaskService = dailyTaskService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDailyTaskById(int id)
        {
            var dailyTask = await _dailyTaskService.GetDailyTaskByIdAsync(id);
            if (dailyTask == null) return NotFound();
            return Ok(dailyTask);
        }

        [HttpGet("coursecalendars/{courseCalendarId}")]
        public async Task<IActionResult> GetDailyTasksByCourseCalendarId(int courseCalendarId)
        {
            var dailyTasks = await _dailyTaskService.GetDailyTasksByCourseCalendarIdAsync(courseCalendarId);
            return Ok(dailyTasks);
        }

        [HttpPost]
        public async Task<IActionResult> AddDailyTask([FromBody] DailyTask dailyTask)
        {
            await _dailyTaskService.AddDailyTaskAsync(dailyTask);
            return CreatedAtAction(nameof(GetDailyTaskById), new { id = dailyTask.Id }, dailyTask);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDailyTask(int id, [FromBody] DailyTask dailyTask)
        {
            if (id != dailyTask.Id) return BadRequest();
            await _dailyTaskService.UpdateDailyTaskAsync(dailyTask);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDailyTask(int id)
        {
            await _dailyTaskService.DeleteDailyTaskAsync(id);
            return NoContent();
        }
    }
}
