using FeedbackAndAssessmentService.Model;

namespace FeedbackAndAssessmentService.Repositories
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetFeedbacksAsync();
        Task<Feedback> GetFeedbackByIdAsync(int id);
        Task<Feedback> AddFeedbackAsync(FeedbackDto feedback);
        Task DeleteFeedbackAsync(int id);
    }
}
