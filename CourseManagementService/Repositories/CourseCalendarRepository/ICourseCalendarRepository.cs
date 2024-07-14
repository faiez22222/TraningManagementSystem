using CourseManagementService.Model;

namespace CourseManagementService.Repositories.CourseCalendarRepository
{
    public interface ICourseCalendarRepository
    {
        Task<CourseCalendar> GetCourseCalendarByIdAsync(int id);
        Task AddCourseCalendarAsync(CourseCalendar courseCalendar);
        Task UpdateCourseCalendarAsync(CourseCalendar courseCalendar);
        Task DeleteCourseCalendarAsync(int id);
    }
}
