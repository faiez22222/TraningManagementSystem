namespace FeedbackAndAssessmentService.Model
{
    public class Feedback
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string CourseContent { get; set; }
        public string ContentDelivery { get; set; }
        public string TutorAvailability { get; set; }
        public string ImplementationOfConcept { get; set; }
        public string Message { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}
