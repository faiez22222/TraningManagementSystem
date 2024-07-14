using CourseManagementService.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementService.Repositories.CourseCalendarRepository
{
    public class CourseCalendarRepository : ICourseCalendarRepository
    {
        private readonly CourseManagementContext _context;

        public CourseCalendarRepository(CourseManagementContext context)
        {
            _context = context;
        }

        public async Task<CourseCalendar> GetCourseCalendarByIdAsync(int id)
        {
            return await _context.CourseCalendars.Include(dt=>dt.DailyTasks).FirstOrDefaultAsync(cc=>cc.Id == id);
        }

        public async Task AddCourseCalendarAsync(CourseCalendar courseCalendar)
        {
            await _context.CourseCalendars.AddAsync(courseCalendar);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCourseCalendarAsync(CourseCalendar courseCalendar)
        {
            _context.CourseCalendars.Update(courseCalendar);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseCalendarAsync(int id)
        {
            var courseCalendar = await GetCourseCalendarByIdAsync(id);
            _context.CourseCalendars.Remove(courseCalendar);
            await _context.SaveChangesAsync();
        }
    }

}
