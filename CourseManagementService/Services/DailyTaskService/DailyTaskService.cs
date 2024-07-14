using CourseManagementService.Model;
using CourseManagementService.Repositories.DailyTaskRepository;

namespace CourseManagementService.Services.DailyTaskService
{
    public class DailyTaskService : IDailyTaskService
    {
        private readonly IDailyTaskRepository _dailyTaskRepository;

        public DailyTaskService(IDailyTaskRepository dailyTaskRepository)
        {
            _dailyTaskRepository = dailyTaskRepository;
        }

        public async Task<DailyTask> GetDailyTaskByIdAsync(int id)
        {
            return await _dailyTaskRepository.GetDailyTaskByIdAsync(id);
        }

        public async Task<IEnumerable<DailyTask>> GetDailyTasksByCourseCalendarIdAsync(int courseCalendarId)
        {
            return await _dailyTaskRepository.GetDailyTasksByCourseCalendarIdAsync(courseCalendarId);
        }

        public async Task AddDailyTaskAsync(DailyTask dailyTask)
        {
            await _dailyTaskRepository.AddDailyTaskAsync(dailyTask);
        }

        public async Task UpdateDailyTaskAsync(DailyTask dailyTask)
        {
            await _dailyTaskRepository.UpdateDailyTaskAsync(dailyTask);
        }

        public async Task DeleteDailyTaskAsync(int id)
        {
            await _dailyTaskRepository.DeleteDailyTaskAsync(id);
        }
    }
}
