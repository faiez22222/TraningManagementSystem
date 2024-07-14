using CourseManagementService.Model;

namespace CourseManagementService.Repositories.CourseRepository
{
    public interface ICourseRepository
    {
        Task<Course> GetCourseByIdAsync(int id);
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int id);
    }
}
