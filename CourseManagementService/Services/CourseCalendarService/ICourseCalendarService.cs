using CourseManagementService.Model;

namespace CourseManagementService.Services.CourseCalendarService
{
    public interface ICourseCalendarService
    {
        Task<CourseCalendar> GetCourseCalendarByIdAsync(int id);
        Task AddCourseCalendarAsync(CourseCalendar courseCalendar);
        Task UpdateCourseCalendarAsync(CourseCalendar courseCalendar);
        Task DeleteCourseCalendarAsync(int id);

        Task<int> GetBatchCountAsync(int courseId);
    }
}
