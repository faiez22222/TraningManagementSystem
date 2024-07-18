using System.Diagnostics.CodeAnalysis;

namespace CourseManagementService.Model
{
    public class CourseCalendar
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        [AllowNull]
        public string? BatchName { get; set; }   
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }


        // Nullable navigation property for DailyTasks
        [AllowNull]
        public ICollection<DailyTask>? DailyTasks { get; set; }
    }
}
