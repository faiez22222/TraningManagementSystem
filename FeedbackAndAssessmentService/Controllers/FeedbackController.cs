using FeedbackAndAssessmentService.Model;
using FeedbackAndAssessmentService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackAndAssessmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
        {
            var feedbacks = await _feedbackRepository.GetFeedbacksAsync();
            return Ok(feedbacks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetFeedback(int id)
        {
            var feedback = await _feedbackRepository.GetFeedbackByIdAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        [HttpPost]
        public async Task<ActionResult<Feedback>> PostFeedback([FromBody] FeedbackDto feedback)
        {
            feedback.SubmittedAt = DateTime.UtcNow;
            var createdFeedback = await _feedbackRepository.AddFeedbackAsync(feedback);
            return CreatedAtAction(nameof(GetFeedback), new { id = createdFeedback.Id }, createdFeedback);
        }

        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            await _feedbackRepository.DeleteFeedbackAsync(id);
            return NoContent();
        }
    }
}
