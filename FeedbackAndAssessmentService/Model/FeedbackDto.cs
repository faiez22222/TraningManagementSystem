namespace FeedbackAndAssessmentService.Model
{
    public class FeedbackDto
    {
        public int EmployeeId { get; set; }
        public int CourseContent { get; set; }
        public int ContentDelivery { get; set; }
        public int TutorAvailability { get; set; }
        public int ImplementationOfConcept { get; set; }
        public string Message { get; set; }
        public DateTime SubmittedAt { get; set; }
    }

}
