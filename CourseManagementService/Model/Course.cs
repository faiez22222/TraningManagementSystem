using System.Diagnostics.CodeAnalysis;

namespace CourseManagementService.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int Duration { get; set; }

        // Navigation property for CourseCalendars
        [AllowNull]
        public ICollection<CourseCalendar>? CourseCalendars { get; set; }

    }
}
