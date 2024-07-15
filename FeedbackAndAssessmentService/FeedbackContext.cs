using FeedbackAndAssessmentService.Model;
using Microsoft.EntityFrameworkCore;

namespace FeedbackAndAssessmentService
{
    public class FeedbackContext:DbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options)
        {
        }
        public DbSet<Feedback> Feedbacks { get; set; }

    }
}
