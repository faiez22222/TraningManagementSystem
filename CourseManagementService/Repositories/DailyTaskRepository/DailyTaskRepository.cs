using CourseManagementService.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementService.Repositories.DailyTaskRepository
{
    public class DailyTaskRepository : IDailyTaskRepository
    {
        private readonly CourseManagementContext _context;

        public DailyTaskRepository(CourseManagementContext context)
        {
            _context = context;
        }

        public async Task<DailyTask> GetDailyTaskByIdAsync(int id)
        {
            return await _context.DailyTasks.FirstOrDefaultAsync(dt => dt.Id == id);
        }

        public async Task<IEnumerable<DailyTask>> GetDailyTasksByCourseCalendarIdAsync(int courseCalendarId)
        {
            return await _context.DailyTasks.Where(dt => dt.CourseCalendarId == courseCalendarId).ToListAsync();
        }

        public async Task AddDailyTaskAsync(DailyTask dailyTask)
        {
            await _context.DailyTasks.AddAsync(dailyTask);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDailyTaskAsync(DailyTask dailyTask)
        {
            _context.DailyTasks.Update(dailyTask);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDailyTaskAsync(int id)
        {
            var dailyTask = await GetDailyTaskByIdAsync(id);
            _context.DailyTasks.Remove(dailyTask);
            await _context.SaveChangesAsync();
        }
    }
}
