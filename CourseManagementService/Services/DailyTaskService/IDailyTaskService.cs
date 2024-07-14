using CourseManagementService.Model;

namespace CourseManagementService.Services.DailyTaskService
{
    public interface IDailyTaskService
    {
        Task<DailyTask> GetDailyTaskByIdAsync(int id);
        Task<IEnumerable<DailyTask>> GetDailyTasksByCourseCalendarIdAsync(int courseCalendarId);
        Task AddDailyTaskAsync(DailyTask dailyTask);
        Task UpdateDailyTaskAsync(DailyTask dailyTask);
        Task DeleteDailyTaskAsync(int id);
    }
}
