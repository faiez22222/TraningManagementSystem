using System.Diagnostics.CodeAnalysis;

namespace BatchManagementService.Model
{
    public class Batch
    {
        public int Id { get; set; } 
        public string BatchName { get; set; }    
        public int CourseId { get; set; }   

        public string BatchTutor {get; set; }
        [AllowNull]
        public ICollection<BatchEnrollment>? Enrollments { get; set; }   

    }
}
