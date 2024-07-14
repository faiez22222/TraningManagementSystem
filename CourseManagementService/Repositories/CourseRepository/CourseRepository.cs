using CourseManagementService.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementService.Repositories.CourseRepository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseManagementContext _context;

        public CourseRepository(CourseManagementContext context)
        {
            _context = context;
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.Include(c => c.CourseCalendar).ThenInclude(cc => cc.DailyTasks).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.Include(c => c.CourseCalendar).ThenInclude(cc => cc.DailyTasks).ToListAsync();
        }

        public async Task AddCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await GetCourseByIdAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}
