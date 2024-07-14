using CourseManagementService.Model;

namespace CourseManagementService.Repositories.DailyTaskRepository
{
    public interface IDailyTaskRepository
    {
        Task<DailyTask> GetDailyTaskByIdAsync(int id);
        Task<IEnumerable<DailyTask>> GetDailyTasksByCourseCalendarIdAsync(int courseCalendarId);
        Task AddDailyTaskAsync(DailyTask dailyTask);
        Task UpdateDailyTaskAsync(DailyTask dailyTask);
        Task DeleteDailyTaskAsync(int id);
    }
}
