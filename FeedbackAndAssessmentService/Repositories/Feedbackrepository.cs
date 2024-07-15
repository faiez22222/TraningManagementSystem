using FeedbackAndAssessmentService.Model;
using FeedbackAndAssessmentService.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FeedbackAndAssessmentService.Repositories
{
    public class Feedbackrepository:IFeedbackRepository
    {
        private readonly FeedbackContext _context;

        public Feedbackrepository(FeedbackContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetFeedbacksAsync()
        {
            return await _context.Feedbacks.ToListAsync();  
        }

        public async Task<Feedback> GetFeedbackByIdAsync(int id)
        {
            return await _context.Feedbacks.FindAsync(id);
        }

        public async Task<Feedback> AddFeedbackAsync(FeedbackDto feedbackDto)
        {
            var feedback = new Feedback
            {
                EmployeeId = feedbackDto.EmployeeId,
                CourseContent = ConvertFeedbackScore(feedbackDto.CourseContent),
                ContentDelivery = ConvertFeedbackScore(feedbackDto.ContentDelivery),
                TutorAvailability = ConvertFeedbackScore(feedbackDto.TutorAvailability),
                ImplementationOfConcept = ConvertFeedbackScore(feedbackDto.ImplementationOfConcept),
                Message = feedbackDto.Message,
                SubmittedAt = DateTime.UtcNow
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }


        public async Task DeleteFeedbackAsync(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
            }
        }

        private string ConvertFeedbackScore(int score)
        {
            return score switch
            {
                5 => "Very Great",
                4 => "Great",
                3 => "Average",
                2 => "Poor",
                1 => "Very Poor",
                _ => "Unknown"
            };
        }
    }
}
