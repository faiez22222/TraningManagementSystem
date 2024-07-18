using CourseManagementService.Model;
using CourseManagementService.Repositories.CourseCalendarRepository;

namespace CourseManagementService.Services.CourseCalendarService
{
    public class CourseCalendarService : ICourseCalendarService
    {
        private readonly ICourseCalendarRepository _courseCalendarRepository;

        public CourseCalendarService(ICourseCalendarRepository courseCalendarRepository)
        {
            _courseCalendarRepository = courseCalendarRepository;
        }

        public async Task<CourseCalendar> GetCourseCalendarByIdAsync(int id)
        {
            return await _courseCalendarRepository.GetCourseCalendarByIdAsync(id);
        }

        public async Task AddCourseCalendarAsync(CourseCalendar courseCalendar)
        {
            int batchCount = await _courseCalendarRepository.GetBatchCountAsync(courseCalendar.CourseId);
            courseCalendar.BatchName = $"Batch-{batchCount + 1}";
            await _courseCalendarRepository.AddCourseCalendarAsync(courseCalendar);
        }

        public async Task UpdateCourseCalendarAsync(CourseCalendar courseCalendar)
        {
            await _courseCalendarRepository.UpdateCourseCalendarAsync(courseCalendar);
        }

        public async Task DeleteCourseCalendarAsync(int id)
        {
            await _courseCalendarRepository.DeleteCourseCalendarAsync(id);
        }

        public async Task<int> GetBatchCountAsync(int courseId)
        {
            return await _courseCalendarRepository.GetBatchCountAsync(courseId);
        }
    }
}
